using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncrpytionAuthentication
{
    class Accounts
    {
        public static Dictionary<string, string> Users { get; set; }
        public static void AddNewUser(string username, string password)
        {
            Users.Add(username, password);
        }

    }
}
