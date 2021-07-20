using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePasswordConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTimePasswordConsoleApp.Utils.Tests
{
    [TestClass()]
    public class ValidatorUserIdTests
    {
        [TestMethod()]
        public void ValidateSuccessTest()
        {
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string userId = "123abc";
            string validatorResult = validatorUserId.Validate(userId);
            Assert.AreEqual(validatorResult, "Valid");
        }

        [TestMethod()]
        public void ValidateFaild1Test()
        {
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string userId = "";
            string validatorResult = validatorUserId.Validate(userId);
            Assert.AreEqual(validatorResult, "The user Id can't be missing!");
        }

        [TestMethod()]
        public void ValidateFaild2Test()
        {
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string userId = "1a.#";
            string validatorResult = validatorUserId.Validate(userId);
            Assert.AreEqual(validatorResult, "The user Id can only contain numbers and letters!");
        }

        [TestMethod()]
        public void ValidateFaild3Test()
        {
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string userId = "123abc4e";
            string validatorResult = validatorUserId.Validate(userId);
            Assert.AreEqual(validatorResult, "The user Id cannot have the length greater than 6!");
        }
    }
}