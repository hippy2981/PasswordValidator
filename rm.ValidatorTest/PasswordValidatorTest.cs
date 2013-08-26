using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using rm.Validator;

namespace rm.ValidatorTest
{
    [TestFixture]
    public class PasswordValidatorTest
    {
        PasswordValidator passwordValidator = new PasswordValidator();
        [Test]
        [TestCase("Passw0rd")]
        [TestCase("P@ssword")]
        [TestCase("P@ssword")]
        //satisfies all optional rules
        [TestCase("P@ssw0rd")]
        [TestCase("P_ssw0rd")]
        [TestCase(" Passw0rd ")]
        public void IsValid_True(string password)
        {
            IEnumerable<string> errors;
            Assert.IsTrue(passwordValidator.IsValid(password, out errors));
            Assert.AreEqual(0, errors.Count());
            PrintErrors(password, errors);
        }
        [Test]
        [TestCase((string)null, 6)]
        [TestCase("", 6)]
        [TestCase("Passw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rdPassw0rd", 1)]
        [TestCase("Password", 2)]
        [TestCase("password", 3)]
        [TestCase("p@ssword", 2)]
        [TestCase("PPP@ssword", 1)]
        public void IsValid_False(string password, int errorsCount)
        {
            IEnumerable<string> errors;
            Assert.IsFalse(passwordValidator.IsValid(password, out errors));
            Assert.AreEqual(errorsCount, errors.Count());
            PrintErrors(password, errors);
        }

        private void PrintErrors(string password, IEnumerable<string> errors)
        {
            Console.WriteLine("password: {0}", password);
            Console.WriteLine("errorsString:");
            Console.WriteLine(string.Join(Environment.NewLine, errors.ToArray()));
        }
    }
}
