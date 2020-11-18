using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail (string email, bool expectedresult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(email);

            Assert.AreEqual(expectedresult, actualResult);
        }

        [
            Test,
            TestCase("abcdABCD", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("Ab1234", false),
            TestCase("Abcd1234", true)
        ]
        public void TestValidatePassword(string password, bool expectedresult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidatePassword(password);

            Assert.AreEqual(expectedresult, actualResult);
        }

        [
            Test,
            TestCase("bce@uni-corvinus.hu", "ABcd1234"),
            TestCase("bce@uni-corvinus.hu", "ABcd123456")
        ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();

            var actualResult = accountController.Register(email, password);

            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }
    }
}
