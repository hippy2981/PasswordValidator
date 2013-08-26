using System.Text.RegularExpressions;

namespace rm.Validator
{
    /// <summary>
    /// Class to encapsulate Regex class.
    /// </summary>
    public class RegEx : Regex
    {
        /// <summary>
        /// Regex's name.
        /// </summary>
        public string Name { get; private set; }
        public RegEx(string pattern, string name, RegexOptions options = RegexOptions.Compiled)
            : base(pattern, options)
        {
            Name = name;
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), Name);
        }
    }
}
