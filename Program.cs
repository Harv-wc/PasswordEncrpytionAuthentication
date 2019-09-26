using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncrpytionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu { };
            mainMenu.DisplayOptions();
            var input = Console.ReadLine();

            do
            {
                while (!Int32.TryParse(input, out _) || (Convert.ToInt32(input) > 3 || Convert.ToInt32(input) < 1))
                {
                    Console.Clear();
                    mainMenu.DisplayOptions();
                    input = Console.ReadLine();
                }
                mainMenu.HandelOption(Convert.ToInt32(input));

            } while (Convert.ToInt32(input) != 3);
            
            Console.WriteLine("Bye!");
        }
    }
}
