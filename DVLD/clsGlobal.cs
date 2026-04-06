using DVLDBusinessLayer;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DVLD
{


    public class clsGlobal
    {
        public static clsUser CurrentUser;


        /// <summary>
        /// Stores the user's credentials (username and password) in the Windows Registry.
        /// The password is encrypted using AES encryption before being stored.
        /// If the username or password is empty, the stored credentials will be removed
        /// from the registry.
        /// </summary>
        /// <param name="Username">The username to be stored.</param>
        /// <param name="Password">The password to be encrypted and stored.</param>
        /// <returns>
        /// Returns true if the credentials were successfully stored or removed;
        /// otherwise returns false if an error occurred.
        /// </returns>
        public static bool RememberUserNameAndPassword(string Username, string Password)
        {

            try
            {
                /*this will get the current project directory folder.
                //string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                //string filePath = @"A:\UserLoginInfo.txt";

                ////incase the username is empty, delete the file
                //if (Username == "" && File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //    return true;

                //}

                //// concatonate username and passwrod withe seperator.
                //string dataToSave = Username + "#//#" + Password;

                //// Create a StreamWriter to write to the file
                //using (StreamWriter writer = new StreamWriter(filePath))
                //{
                //    // Write the data to the file
                //    writer.WriteLine(dataToSave);

                //    return true;
                //}*/




                string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVDL";

                ////in case the username is empty, delete the UserName And Password From Registry
                if (Username == "" || Password == "")
                {
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(KeyPath, true))
                        {
                            if (key != null)
                            {
                                // Delete the specified value
                                key.DeleteValue("Username");
                                key.DeleteValue("Password");
                                return true;
                            }
                        }

                    }
                }


                //store username and password in Registry As Encrypted Password
                Registry.SetValue(KeyPath, "Username", Username, RegistryValueKind.String);

                // Encrypt The Pssword then sorte it in Registry
                Registry.SetValue(KeyPath, "Password", Encrypt(Password, "1234567890123456"), RegistryValueKind.String);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        /// <summary>
        /// Retrieves the stored username and encrypted password from the Windows Registry.
        /// The password is decrypted before being returned.
        /// </summary>
        /// <param name="Username">
        /// A reference parameter that will contain the retrieved username if it exists.
        /// </param>
        /// <param name="Password">
        /// A reference parameter that will contain the decrypted password if it exists.
        /// </param>
        /// <returns>
        /// Returns true if the stored credentials were found and successfully retrieved;
        /// otherwise returns false.
        /// </returns>
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                /*gets the current project's directory
                //string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                //string filePath = @"A:\UserLoginInfo.txt";

                //// Check if the file exists before attempting to read it
                //if (File.Exists(filePath))
                //{
                //    // Create a StreamReader to read from the file
                //    using (StreamReader reader = new StreamReader(filePath))
                //    {
                //        // Read data line by line until the end of the file
                //        string line;
                //        while ((line = reader.ReadLine()) != null)
                //        {

                //            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                //            Username = result[0];
                //            Password = result[1];
                //        }
                //        return true;
                //    }
                //}

                //else
                //{
                //    return false;
                //} */

                // Get UserName And Password From Registry And Decrypt the Password
                string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVDL";
                Username = Registry.GetValue(KeyPath, "Username", null) as string;

                //Decrypt the Password
                Password = Decrypt(Registry.GetValue(KeyPath, "Password", null) as string, "1234567890123456");

                if (Username != null && Password != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        /// <summary>
        /// Encrypts a plain text string using the AES symmetric encryption algorithm.
        /// The method converts the input text into encrypted data using the provided key
        /// and returns the result as a Base64 encoded string.
        /// </summary>
        /// <param name="plainText">The original text that will be encrypted.</param>
        /// <param name="key">The secret key used for AES encryption. The key must have a valid AES length.</param>
        /// <returns>A Base64 encoded string representing the encrypted data.</returns>
        static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts a Base64 encoded cipher text that was encrypted using AES encryption.
        /// The method converts the encrypted data back into the original plain text
        /// using the same secret key.
        /// </summary>
        /// <param name="cipherText">The Base64 encoded encrypted text.</param>
        /// <param name="key">The secret key used for AES decryption.</param>
        /// <returns>The decrypted original plain text.</returns>
        static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }

}

