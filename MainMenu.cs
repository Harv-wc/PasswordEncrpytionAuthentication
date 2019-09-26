using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncrpytionAuthentication
{
    class MainMenu
    {
        private MD5 myKey = MD5.Create();
        public string Header()
        {
            Console.Clear();
            string header = "User Account Authentication\n###########################\n";
            return header;
        }
            
        public void DisplayOptions()
        {
            Console.WriteLine($"{Header()}" +
                $"1. Create Account\n" +
                $"2. Login\n" +
                $"3. Exit");
        }

        public void HandelOption(int input)
        {
            switch(input)
            {
                case 1: // create account
                    bool badUserName;
                    string userName;
                    do
                    {
                        Console.Write($"{Header()}\n" +
                            $"Enter a user name: ");
                        userName = Console.ReadLine();
                        badUserName = false;
                        if (Accounts.Users.ContainsKey(userName))
                        {
                            badUserName = true;
                            Console.WriteLine($"Username already exists");
                            Console.ReadKey();
                        }
                    } while (badUserName);
                    Console.Write($"\nEnter a password: ");
                    string password = GetMd5Hash(myKey, Console.ReadLine());
                    Accounts.AddNewUser(userName, password);
                    break;
                case 2: // login

                case 3: // exit
                    break;
                default:
                    throw new Exception("Invalid Option selection");

            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
