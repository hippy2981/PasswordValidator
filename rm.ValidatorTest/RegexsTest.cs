using System.Text.RegularExpressions;
using NUnit.Framework;
using rm.Validator;

namespace rm.ValidatorTest
{
    [TestFixture]
    public class RegexsTest
    {
        [Test]
        [TestCase("a", Regexs.LowerCase)]
        [TestCase("aAbB", Regexs.LowerCase)]
        [TestCase("Aa", Regexs.UpperCase)]
        [TestCase("AB", Regexs.UpperCase)]
        [TestCase("0", Regexs.Numeric)]
        [TestCase("aA0", Regexs.Numeric)]
        public void LowerUpperNumeric_True(string input, string regex)
        {
            Assert.IsTrue(Regex.Match(input, regex).Success);
        }
        [Test]
        [TestCase("", Regexs.LowerCase)]
        [TestCase(" ", Regexs.LowerCase)]
        [TestCase("A9", Regexs.LowerCase)]
        [TestCase("", Regexs.UpperCase)]
        [TestCase(" ", Regexs.UpperCase)]
        [TestCase("a9", Regexs.UpperCase)]
        [TestCase("", Regexs.Numeric)]
        [TestCase(" ", Regexs.Numeric)]
        [TestCase("aA", Regexs.Numeric)]
        public void LowerUpperNumeric_False(string input, string regex)
        {
            Assert.IsFalse(Regex.Match(input, regex).Success);
        }

        [Test]
        [TestCase("12345678", Regexs.Length)]
        [TestCase("1234567890", Regexs.Length)]
        public void Length_True(string input, string regex)
        {
            Assert.IsTrue(Regex.Match(input, regex).Success);
        }
        [Test]
        [TestCase("", Regexs.Length)]
        [TestCase("1134567", Regexs.Length)]
        [TestCase("01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567", Regexs.Length)]
        public void Length_False(string input, string regex)
        {
            Assert.IsFalse(Regex.Match(input, regex).Success);
        }

        [Test]
        [TestCase("-", Regexs.Special)]
        [TestCase(" ", Regexs.Special)]
        [TestCase(" -", Regexs.Special)]
        [TestCase("&", Regexs.Special)]
        [TestCase("_", Regexs.Special)]
        public void Special_True(string input, string regex)
        {
            Assert.IsTrue(Regex.Match(input, regex).Success);
        }
        [Test]
        [TestCase("", Regexs.Special)]
        [TestCase("a", Regexs.Special)]
        [TestCase("A", Regexs.Special)]
        [TestCase("0", Regexs.Special)]
        public void Special_False(string input, string regex)
        {
            Assert.IsFalse(Regex.Match(input, regex).Success);
        }

        [Test]
        [TestCase("aa", Regexs.NonRepeating)]
        [TestCase("aa0a", Regexs.NonRepeating)]
        [TestCase("$$", Regexs.NonRepeating)]
        [TestCase("00", Regexs.NonRepeating)]
        [TestCase("AA", Regexs.NonRepeating)]
        public void NonRepeating_True(string input, string regex)
        {
            Assert.IsTrue(Regex.Match(input, regex).Success);
        }
        [Test]
        [TestCase("aaa", Regexs.NonRepeating)]
        [TestCase("aaaa", Regexs.NonRepeating)]
        [TestCase("aa0aaa", Regexs.NonRepeating)]
        [TestCase("$$$", Regexs.NonRepeating)]
        [TestCase("000", Regexs.NonRepeating)]
        [TestCase("AAA", Regexs.NonRepeating)]
        public void NonRepeating_False(string input, string regex)
        {
            Assert.IsFalse(Regex.Match(input, regex).Success);
        }
    }
}
