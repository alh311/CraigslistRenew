using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CraigslistRenew
{
    public class CraigslistBot
    {
        private readonly ChromeDriver _browser;
        private readonly WebDriverWait _wait;
        private readonly string _url = "https://accounts.craigslist.org/login";
        private readonly string _email;
        private readonly string _password;

        public CraigslistBot(ChromeDriver browser, string email, string password)
        {
            _browser = browser;
            _email = email;
            _password = password;
            _wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(30));
        }

        public async Task Start()
        {
            Console.WriteLine($"\nCREATED BY ALEX HUTCHINS");
            Console.WriteLine($"\nStarting up the {nameof(CraigslistBot)}...");

            _browser.Navigate().GoToUrl(_url);
            await WaitForDocumentReady();
            LogPage();

            await SignIn();
            var renewCount = RenewListings();
            await LogRenewedListings(renewCount);
        }

        private async Task SignIn()
        {
            Log("Signing in...");

            var emailSelector = By.Id("inputEmailHandle");
            EnterFieldValue(emailSelector, _email);

            var passwordSelector = By.Id("inputPassword");
            EnterFieldValue(passwordSelector, _password);

            _browser.FindElement(By.Id("login")).Click();
            await WaitForDocumentReady();
            LogPage();
        }

        private int RenewListings()
        {
            // Debug Version (Selects "Display" buttons
            //var renewButtons = _browser.FindElements(By.CssSelector("input[value='display'][type='submit']"));

            var renewButtons = _browser.FindElements(By.CssSelector("input[value='renew'][type='submit']"));

            var renewCount = renewButtons.Count;

            if (renewCount > 0)
            {
                var actions = new Actions(_browser)
                    .KeyDown(Keys.Command);

                // Click each button while "holding down" the Command key.
                foreach (var button in renewButtons)
                {
                    actions = actions.Click(button);
                }

                actions.KeyUp(Keys.Command)
                    .Build()
                    .Perform();
            }

            return renewCount;
        }

        private async Task LogRenewedListings(int renewCount)
        {
            // Close the account main page
            _browser.Close();

            if (renewCount > 0)
            {
                await HoldOn(500);

                Log("");
                Log("Renewed Listings:");

                foreach (var window in _browser.WindowHandles)
                {
                    _browser.SwitchTo().Window(window);

                    var itemTitleSelector = By.Id("titletextonly");
                    if (await WaitForElement(30, itemTitleSelector))
                    {
                        Log($"\t{_browser.FindElement(itemTitleSelector).Text}");
                    }

                    _browser.Close();
                }

                Log("");
                Log($"[{renewCount} Listings Renewed]");
            }
            else
            {
                Log("");
                Log($"No listings to renew.");
            }
        }

        private async Task HoldOn(int ms)
        {
            await Task.Delay(ms);
        }

        private async Task WaitForDocumentReady()
        {
            await HoldOn(500);
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        private async Task<bool> WaitForElement(int attempts, By selector)
        {
            for (var a = attempts; a > 0; --a)
            {
                if (_browser.ElementExists(selector))
                    return true;

                await HoldOn(100);
            }
            return false;
        }

        private void EnterFieldValue(By by, string value)
        {
            var field = _browser.FindElement(by);
            field.Clear();
            field.SendKeys(value);
        }

        private void LogPage()
        {
            Console.WriteLine($"\n--- PAGE: {_browser.Title} ---");
        }

        private void Log(string message)
        {
            Console.WriteLine($"\t{message}");
        }

        private void LogFailure(string message, [CallerMemberName] string callerName = null)
        {
            Log($"FAILURE: {message} (Caller: {callerName})");
        }
    }
}
