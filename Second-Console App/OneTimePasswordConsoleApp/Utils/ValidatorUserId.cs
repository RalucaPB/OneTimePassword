using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTimePasswordConsoleApp.Utils
{
    public class ValidatorUserId
    {
        /// <summary> 
        /// Check if the user id is valid. 
        /// </summary> 
        /// <param name="userId">
        /// userId to be checked
        /// </param>
        /// <returns>
        /// A string 
        /// "Valid"-if the given userId is valid
        /// "The user Id can't be missing!"-if the given userId is missing
        /// "The user Id can only contain numbers and letters!"-
        /// if the given userIdcontains anything other than numbers and letters
        /// "The user Id cannot have the length greater than 6!"-
        /// if the userId's length is greater than 6
        /// </returns>
        public string Validate(string userId)
        {
            string result = "Valid";
            if (userId == "" || userId == null)
            {
                result = "The user Id can't be missing!";
            }
            if (!userId.All(c => Char.IsLetterOrDigit(c)))
            {
                result = "The user Id can only contain numbers and letters!";
            }
            if (userId.Length > 6)
            {
                result = "The user Id cannot have the length greater than 6!";
            }
            return result;
        }
    }
}
