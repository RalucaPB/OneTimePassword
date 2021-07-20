using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePasswordConsoleApp.Interfaces;
using OneTimePasswordConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTimePasswordConsoleApp.Tests
{
    [TestClass()]
    public class CryptographyServiceTests
    {
        [TestMethod()]

        public void CryptographyTest()
        {
            ICryptographyService cryptographyService = new CryptographyService();
            string message = "123Abc";
            string encryptedMessage = cryptographyService.Encrypt(message);
            string decryptedMessage = cryptographyService.Decrypt(encryptedMessage);
            Assert.AreEqual(message, decryptedMessage);
        }

    }
}