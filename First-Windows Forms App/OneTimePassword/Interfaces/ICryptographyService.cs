using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Interfaces
{
    public interface ICryptographyService
    {
        /// <summary> 
        /// Encrypt a string. 
        /// </summary> 
        /// <param name="message">
        /// String to be encrypted
        /// </param> 
        /// <returns>
        /// A string representing the encrypted message
        /// </returns>
        string Encrypt(string message);

        /// <summary> 
        /// Decrypt a string. 
        /// </summary> 
        /// <param name="message">
        /// String to be decrypted
        /// </param> 
        /// <returns>
        /// A string representing the decrypted message
        /// </returns>
        string Decrypt(string message);
    }
}
