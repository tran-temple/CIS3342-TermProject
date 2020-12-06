using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Net.Mail;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EcommerceLibrary
{
    public class Utilities
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        public string Encrypt(string plainTextPassword)
        {
            String encryptedPassword;
            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
            Byte[] textBytes;                               // stores the plain text data as bytes

            // Perform Encryption
            //-------------------
            // Convert a string to a byte array, which will be used in the encryption process.
            textBytes = encoder.GetBytes(plainTextPassword);

            // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,
            // a memory stream used to store the encrypted data temporarily, and
            // a crypto stream that performs the encryption algorithm.
            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            // Use the crypto stream to perform the encryption on the plain text byte array.        
            myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            myEncryptionStream.FlushFinalBlock();

            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
            myMemoryStream.Position = 0;
            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

            // Close all the streams.
            myEncryptionStream.Close();
            myMemoryStream.Close();

            // Convert the bytes to a string
            encryptedPassword = Convert.ToBase64String(encryptedBytes);
            return encryptedPassword;
        }

        public string Decrypt(string encryptedPassword)
        {
            String plainTextPassword;
            Byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
            Byte[] textBytes;
            UTF8Encoding encoder = new UTF8Encoding();            

            // Perform Decryption
            //-------------------
            // Create an instances of the decryption algorithm (Rinjdael AES) for the encryption to perform,
            // a memory stream used to store the decrypted data temporarily, and
            // a crypto stream that performs the decryption algorithm.
            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

            // Use the crypto stream to perform the decryption on the encrypted data in the byte array.
            myDecryptionStream.Write(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
            myDecryptionStream.FlushFinalBlock();

            // Retrieve the decrypted data from the memory stream, and write it to a separate byte array.
            myMemoryStream.Position = 0;
            textBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(textBytes, 0, textBytes.Length);

            // Close all the streams.
            myDecryptionStream.Close();
            myMemoryStream.Close();

            // Convert the bytes to a string
            plainTextPassword = encoder.GetString(textBytes);
            return plainTextPassword;
        }

        // Encrypt sensitive info to store DB
        public string EncryptSensitiveInfo(string sensInfo)
        {
            string encryptedPassword;

            SHA256 mySHA256 = SHA256.Create();
            byte[] result = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(sensInfo));

            encryptedPassword = Convert.ToBase64String(result);
            return encryptedPassword;
        }

        //Create URL for confirm password
        public string CreateConfirmUrl(string host, int port, string key)
        {
            string confirmUrl = "http://" + host + ":" + port + "/ConfirmUser.aspx?key=" + key;
            return confirmUrl;
        }

        //Create URL for new password
        public string CreateNewtPasswordUrl(string host, int port, string key)
        {
            string confirmUrl = "http://" + host + ":" + port + "/NewPassword.aspx?key=" + key;
            return confirmUrl;
        }

        //Create key to send email for verfify email user
        public string CreateKey(string username)
        {
            string key = EncryptSensitiveInfo(username);
            return key;
        }

        public void SendEmail(string key, string recipient, string subject, string url, string information, string promotion)
        {
            try
            {
                //For the production - the credential should be in the config file.
                //This credential is temporary for this term project
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("tran.temple.2020@gmail.com", "Temple2020!");
                smtpClient.EnableSsl = true;

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("tran.temple.2020@gmail.com");
                mail.To.Add(recipient);
                /*mail.Subject = "RH Chocolate Store: Activate";
                mail.Body = "Please click the link to activate your account! " +
                    "<br/> <a href='" + url + "'>" + url + "</a>" + "<br/><br> Enter coupoun code NEW15 for 15% off your first order!" ;*/
                mail.Subject = subject;
                mail.Body = information +
                    "<br/> <a href='" + url + "'>" + url + "</a>" + "<br/><br/>" + promotion;
                mail.IsBodyHtml = true;

                smtpClient.Send(mail);
                //System.Diagnostics.Debug.WriteLine("Sent Email");
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        //Verify that the email address is valid or not
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        //Verify that the phone number is valid or not
        public bool IsValidPhone(string phone)
        {
            try
            {
                Regex phonePattern = new Regex(@"^[2-9]\d{2}-\d{3}-\d{4}$"); // US Phone number pattern
                return phonePattern.IsMatch(phone);
            }
            catch (Exception e)
            {
                return false;
            }            
        }

        //Verify that the zip code is valid or not
        public bool IsValidZipCode(string zipcode)
        {
            Regex zipCodePattern = new Regex(@"^\d{5}$");
            return zipCodePattern.IsMatch(zipcode);
        }

        //Verify card number
        public bool IsValidCardNumber(string cardNumber)
        {
            Regex pattern = new Regex(@"^\d{16}$");
            return pattern.IsMatch(cardNumber);
        }

        //Verify that the password is valid or not
        /* RegEx Description:
        ^	            The password string will start this way
        (?=.*[a-z])	    The string must contain at least 1 lowercase alphabetical character
        (?=.*[A-Z])	    The string must contain at least 1 uppercase alphabetical character
        (?=.*[0-9])	    The string must contain at least 1 numeric character
        (?=.*[!@#\$%])	The string must contain at least one special character
        (?=.{8,})	    The string must be eight characters or longer
         */
        public bool IsValidPassword(string password)
        {
            try
            {
                Regex passwordPattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
                return passwordPattern.IsMatch(password);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
