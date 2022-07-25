using System;
using System.IO;

namespace CraigslistRenew
{
    public static class SettingsLoader
    {
        private static string _fileName = "settings.txt";

        public static Settings LoadSettings()
        {
            //AppContext.BaseDirectory

            var lines = File.ReadAllLines(_fileName);
            return new Settings(lines[0], lines[1], lines[2]);
        }
    }
}
