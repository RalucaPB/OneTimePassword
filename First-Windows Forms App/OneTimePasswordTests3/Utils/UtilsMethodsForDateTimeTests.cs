using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePassword.Interfaces;
using OneTimePassword.Services;
using OneTimePassword.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTimePassword.Utils.Tests
{
    [TestClass()]
    public class UtilsMethodsForDateTimeTests
    {
        [TestMethod()]
        public void GetDateTimeSuccessTest()
        {
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            DateTime date = new DateTime(2021, 7, 10, 8, 30, 0);
            string message = "123Abc#" + date;
            DateTime result = utils.GetDateTime(message);
            Assert.AreEqual(result, date);
        }
        [TestMethod()]
        public void GetDateTimeFaildTest()
        {
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            string message = "123Abc#a123mg23s";
            DateTime result = utils.GetDateTime(message);
            Assert.AreEqual(result, DateTime.MaxValue);
        }

        [TestMethod()]
        public void ValidateSuccessOneTimePasswordTest()
        {
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            bool result = utils.ValidateOneTimePassword(DateTime.Now);
            Assert.AreEqual(result, true);
        }
        [TestMethod()]
        public void ValidateFaildOneTimePasswordTest()
        {
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            bool result = utils.ValidateOneTimePassword(DateTime.Now.AddSeconds(-31));
            Assert.AreEqual(result, false);
        }
    }
}