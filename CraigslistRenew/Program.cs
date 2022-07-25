using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace CraigslistRenew
{
    class Program
    {
        public static async Task Main()
        {
            if (SettingsLoader.TryLoadSettings(out var settings))
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
                chromeDriverService.SuppressInitialDiagnosticInformation = true;

                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
                chromeOptions.AddArgument("--ignore-certificate-errors");
                chromeOptions.AddArgument("window-size=1280,800");
                chromeOptions.AddArgument($"user-agent={settings.UserAgent}");
                chromeOptions.AddArguments("headless");
                chromeOptions.AddExcludedArgument("enable-automation");
                chromeOptions.AddAdditionalOption("useAutomationExtension", false);

                using var browser = new ChromeDriver(chromeDriverService, chromeOptions);
                browser.ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})");

                var bot = new CraigslistBot(browser, settings.Email, settings.Password);
                await bot.Start();
            }
        }
    }
}
