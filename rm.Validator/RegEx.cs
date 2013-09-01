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
        public bool ExpectedMatch { get; private set; }
        public RegEx(string pattern, string name, bool expectedMatch = true,
            RegexOptions options = RegexOptions.Compiled)
            : base(pattern, options)
        {
            Name = name;
            ExpectedMatch = expectedMatch;
        }
        public override string ToString()
        {
            return string.Format("{0} ({2}{1})", 
                base.ToString(), Name, ExpectedMatch ? "" : "~");
        }
    }
}
