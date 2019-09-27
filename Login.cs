using System;

namespace PasswordEncrpytionAuthentication
{
    class Login
    {
        public string Username { get; set; }
        public Login(string username)
        {
            Username = username;
        }

        public void DisplayLoginPage()
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                LoginHeader();
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 3:
                            loggedIn = false;
                            break; ;
                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine($"Invalid input. Please try again...\n(Ok)");
                    Console.ReadKey();
                }
            }
        }
        public void LoginHeader()
        {
            Console.Clear();
            Console.WriteLine($"Logged in as {Username}.\n" +
                $"##############################");
            Console.WriteLine($"Logging work hours...\n" +
                $"Enter 3 to end work and log out.");
        }

    }
}
