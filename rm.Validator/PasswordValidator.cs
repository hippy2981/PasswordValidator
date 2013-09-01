using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace rm.Validator
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class PasswordValidator : IValidate<string>
    {
        #region rules

        /// <summary>
        /// Required rules that password MUST satisfy.
        /// </summary>
        private static readonly RegEx[] requiredRegexs = 
        {
            new RegEx(Regexs.Length, "Length"),
            //new RegEx(Regexs.NonRepeating, "NonRepeating"),
            new RegEx(Regexs.Repeating, "Repeating", false),
        };
        /// <summary>
        /// Optional rules that password should satisfy some.
        /// </summary>
        private static readonly RegEx[] optionalRegexs = 
        {
            new RegEx(Regexs.LowerCase, "LowerCase"),
            new RegEx(Regexs.UpperCase, "UpperCase"),
            new RegEx(Regexs.Numeric, "Numeric"),
            new RegEx(Regexs.Special, "Special"),
        };
        /// <summary>
        /// Minimum optional rules (regexs) for password to satisfy (match).
        /// </summary>
        private static readonly int minimumOptionalRulesToSatisfy = optionalRegexs.Length - 1;

        #endregion

        #region errors

        private static readonly string[] noErrors = new string[0];
        private static readonly string[] allErrors = GetAllErrors();
        private static string[] GetAllErrors()
        {
            var errors = new List<string>(requiredRegexs.Length + optionalRegexs.Length);
            errors.AddRange(requiredRegexs.Select(x => x.ToString()));
            errors.AddRange(optionalRegexs.Select(x => x.ToString()));
            return errors.ToArray();
        }
        /// <summary>
        /// Select regexs that did not match.
        /// </summary>
        private IEnumerable<string> GetRegexsForFalseFlags(bool[] flags, RegEx[] regexs)
        {
            // select indexes of false items
            var indexes = flags
                .Select((flag, index) => new { flag, index })
                .Where(fi => !fi.flag)
                .Select(fi => fi.index);
            var errors = new List<string>(indexes.Count());
            foreach (var index in indexes)
            {
                errors.Add(regexs[index].ToString());
            }
            return errors;
        }
        
        #endregion

        #region IValidate<string> methods

        public bool IsValid(string password, out IEnumerable<string> errors)
        {
            if (password == null)
            {
                errors = allErrors;
                return false;
            }
            var isValid = false;
            // required regexs
            var requiredRegexsFlags = requiredRegexs
                .Select(x => x.IsMatch(password) == x.ExpectedMatch).ToArray();
            var requiredRegexsCombinedFlag = true;
            foreach (var requiredRegexsFlag in requiredRegexsFlags)
            {
                requiredRegexsCombinedFlag &= requiredRegexsFlag;
            }
            // optional regexs
            var optionalRegexsFlags = optionalRegexs
                .Select(x => x.IsMatch(password) == x.ExpectedMatch).ToArray();
            var optionalRegexsCombinedFlag = optionalRegexsFlags.Count(x => x) >= minimumOptionalRulesToSatisfy;
            // all required rules + atleast some of optional rules
            isValid = requiredRegexsCombinedFlag && optionalRegexsCombinedFlag;
            // errors
            if (isValid)
            {
                errors = noErrors;
            }
            else
            {
                var errorList = new List<string>(
                    requiredRegexsFlags.Count(x => !x) +
                    (optionalRegexsCombinedFlag ? 0 : optionalRegexsFlags.Count(x => !x))
                );
                errorList.AddRange(GetRegexsForFalseFlags(requiredRegexsFlags, requiredRegexs));
                if (!optionalRegexsCombinedFlag)
                {
                    errorList.AddRange(GetRegexsForFalseFlags(optionalRegexsFlags, optionalRegexs));
                }
                errors = errorList.AsEnumerable();
            }
            return isValid;
        }

        public bool IsValid(string password)
        {
            IEnumerable<string> errors;
            return IsValid(password, out errors);
        }

        #endregion
    }
}
