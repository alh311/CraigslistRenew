using System;
using System.Collections.Generic;
using System.IO;

namespace CRSetup
{
    public class SetterUpper
    {
        private static string _fileName = ".settings";

        public void Run()
        {
            Console.Write("\nEnter your Craigslist email address: ");
            var email = Console.ReadLine();

            Console.Write("\nEnter your Craigslist password: ");
            var password = GetPassword();

            Console.Write("\nPaste in your browser's user agent.\nThis can be found by googling 'my user agent'.\nEnter the full value: ");
            var userAgent = Console.ReadLine();

            // Using HashSet here because of a bug with PublishTrimmed project property in net core 3.0.
            // This wouldn't cause an issue unless the user's password matches their email address,
            // which would just be dumb on their part.
            // I would have used a string[] (or List<string>).
            var lines = new HashSet<string>() { email, password, userAgent };

            try
            {
                File.WriteAllLines(_fileName, lines);
                Console.WriteLine("\nCraigslistRenew is set up and ready to run!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nAn issue was encountered while setting up:\n{e.Message}\n");
            }
        }

        private string GetPassword()
        {
            var password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.Write("\n");

            return password;
        }
    }
}
