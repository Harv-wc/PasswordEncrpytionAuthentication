using System;
// ***** NOT SECURE ***** REMEMBER! MD5 is not something you want to use for encryption! ***** NOT SECURE *****
namespace PasswordEncrpytionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu { };
            var userInput = "";
            do
            {
                mainMenu.DisplayOptions();
                userInput = Console.ReadLine();
                while (!Int32.TryParse(userInput, out _) || (Convert.ToInt32(userInput) > 3 || Convert.ToInt32(userInput) < 1))
                {
                    Console.Clear();
                    mainMenu.DisplayOptions();
                    userInput = Console.ReadLine();
                }
                mainMenu.HandelOption(Convert.ToInt32(userInput));

            } while (Convert.ToInt32(userInput) != 3);
            Console.Clear();
            Console.WriteLine("Bye!");
        }
    }
}
