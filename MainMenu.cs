using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncrpytionAuthentication
{
    class MainMenu
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        private MD5 md5Key = MD5.Create();
        public void HandelOption(int input)
        {
            bool badUserName;
            string userName;
            string password;
            switch (input)
            {
                case 1: // create account
                    do
                    {
                        Console.Write($"{Header()}" +
                            $"Create New Account\n" +
                            $"Enter a user name: ");
                        userName = Console.ReadLine();
                        badUserName = false;
                        if (users.ContainsKey(userName))
                        {
                            badUserName = true;
                            Console.WriteLine($"Username already exists");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Username {userName} accepted!");
                        }
                    } while (badUserName);
                    Console.Write($"\nEnter a password: ");
                        password = GetMd5Hash(md5Key, Console.ReadLine());
                        AddNewUser(userName, password);
                    Console.WriteLine($"Account created successfully!");
                    Console.ReadKey();
                    break;
                case 2: // login
                    Console.Write($"{Header()}" +
                            $"Login\n" +
                            $"Enter a user name: ");
                        userName = Console.ReadLine();
                    Console.Write($"\nEnter a password: ");
                        password = GetMd5Hash(md5Key, Console.ReadLine());
                    if (users.ContainsKey(userName))
                    {
                        if(users[userName] == password)
                        {
                            // Login page
                            Console.WriteLine("login Successful!");
                            Console.ReadKey();
                            Login ThisUser = new Login(userName) { };
                            ThisUser.DisplayLoginPage();
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect password.");
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid user account.");
                        Console.ReadKey();
                        break;
                    }
                    break;
                case 3: // exit
                    break;
                default:
                    throw new Exception("Invalid Option selection");
            }
        }
        public string Header()
        {
            Console.Clear();
            string header = "User Account Authentication\n" +
                "##############################\n";
            return header;
        }
        public void DisplayOptions() // user input options
        {
            Console.WriteLine($"{Header()}" +
                $"1. Create Account\n" +
                $"2. Login\n" +
                $"3. Exit");
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            string potato = "Str0ng3RP@$$w0Rdz4r3!mp()rt4nt";
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(potato + input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static void AddNewUser(string username, string password)
        {
            users.Add(username, password);
        }
    }
}
