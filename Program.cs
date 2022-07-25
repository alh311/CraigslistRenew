using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace CraigslistRenew
{
    class MainClass
    {
        public static async Task Main()
        {
            var settings = SettingsLoader.LoadSettings();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("window-size=1280,800");
            chromeOptions.AddArgument($"user-agent={settings.UserAgent}");
            chromeOptions.AddArguments("headless");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalOption("useAutomationExtension", false);

            using var browser = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
            browser.ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})");

            var bot = new CraigslistBot(browser, settings.Email, settings.Password);
            await bot.Start();
        }
    }
}
