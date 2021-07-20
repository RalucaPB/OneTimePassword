using System;
using System.Collections.Generic;
using System.Text;

namespace OneTimePassword.Utils
{
    public class UtilsMethodsForDateTime
    {
        /// <summary> 
        /// Get the date time from a string. 
        /// </summary> 
        /// <param name="message">
        /// String to be splitted
        /// </param> 
        /// <returns>
        /// A date time representing the date time from the string(input)
        /// </returns>
        public DateTime GetDateTime(string message)
        {
            string[] parts = message.Split('#');
            try
            {
                DateTime dateTime = DateTime.Parse(parts[1]);
                return dateTime;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{parts[1]}'");
                return DateTime.MaxValue;
            }
          
          
        }

        /// <summary> 
        /// Check if the date time is valid. 
        /// </summary> 
        /// <param name="dateTime">
        /// Date time to be checked
        /// </param>
        /// <returns>
        /// A bool
        /// true-if the given dateTime is valid
        /// false-if the given dateTime is not valid
        /// </returns>
        public bool ValidateOneTimePassword(DateTime dateTime)
        {
            double time = (DateTime.Now - dateTime).TotalSeconds;
            return time <= 30;
        }
    }
}
