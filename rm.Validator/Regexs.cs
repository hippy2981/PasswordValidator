namespace rm.Validator
{
    /// <summary>
    /// Class to hold regexs.
    /// </summary>
    public static class Regexs
    {
        /// <summary>Length between 8-127 regex.</summary>
        public const string Length = "^.{8,127}$";
        /// <summary>Lower case regex.</summary>
        public const string LowerCase = "[a-z]+";
        /// <summary>Upper case regex.</summary>
        public const string UpperCase = "[A-Z]+";
        /// <summary>Numeric regex.</summary>
        public const string Numeric = @"\d+";
        /// <summary>Special characters regex.</summary>
        public const string Special = @"[^a-zA-Z\d]";
        /// <summary>No more than 2 identical characters in a row regex.</summary>
        /// <remarks>http://stackoverflow.com/questions/16717656/regex-no-more-than-2-identical-consecutive-characters-and-a-z-and-0-9</remarks>
        public const string NonRepeating = @"^((.)\2?(?!\2))+$";
    }
}
