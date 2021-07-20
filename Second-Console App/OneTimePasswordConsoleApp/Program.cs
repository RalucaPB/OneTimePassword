using OneTimePasswordConsoleApp.Interfaces;
using OneTimePasswordConsoleApp.Services;
using OneTimePasswordConsoleApp.Utils;
using System;

namespace OneTimePasswordConsoleApp
{
    class Program
    {
        static readonly ICryptographyService cryptographyService = new CryptographyService();
        static string oneTimePassword = "";
       
        static void Main(string[] args)
        {
            bool show = true;
            while (show)
            {
                show = Menu();
            }
        }

        private static bool Menu()
        {
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Generate a one-time password");
            Console.WriteLine("2 - Validate the one-time password");
            Console.WriteLine("3 - Exit");
            

            switch (Console.ReadLine())
            {
                case "1":
                    GenerateTheOneTimePassword();
                    return true;
                case "2":
                    Validate();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static void Validate()
        {
            if(oneTimePassword == "")
            {
                Console.WriteLine("The first time you need to generate a one-time password!");
                return;
            }
            UtilsMethodsForDateTime utils = new UtilsMethodsForDateTime();
            string message = cryptographyService.Decrypt(oneTimePassword);
            DateTime dateTime = utils.GetDateTime(message);
            if (utils.ValidateOneTimePassword(dateTime))
            {
               Console.WriteLine("The one time password is valid");
            }
            else
            {
                Console.WriteLine("The one time password is not valid");
               
            }
        }

        private static void GenerateTheOneTimePassword()
        {
            Console.WriteLine("UserId = ");
            string userId = Console.ReadLine(); ;
            ValidatorUserId validatorUserId = new ValidatorUserId();
            string validatorResult = validatorUserId.Validate(userId);
            if (validatorResult != "Valid")
            {
                Console.WriteLine(validatorResult);
                return;
            }
            DateTime dateTime = DateTime.Now;
            string message = userId + "#" + dateTime;
            oneTimePassword = cryptographyService.Encrypt(message);
            Console.WriteLine("One-Time Password:");
            Console.WriteLine(oneTimePassword);
        }
    }
}
