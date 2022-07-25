using System;
using System.IO;

namespace CraigslistRenew
{
    public static class SettingsLoader
    {
        private static string _fileName = ".settings";

        public static bool TryLoadSettings(out Settings settings)
        {
            try
            {
                var lines = File.ReadAllLines(_fileName);
                settings = new Settings(lines[0], lines[1], lines[2]);
                return true;
            }
            catch
            {
                Console.WriteLine("\nThere was an issue loading the settings.  Please run CRSetup first.\n");
                settings = null;
                return false;
            }
        }
    }
}
