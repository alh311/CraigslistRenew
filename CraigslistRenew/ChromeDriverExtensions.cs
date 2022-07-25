using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CraigslistRenew
{
    public static class ChromeDriverExtensions
    {
        public static bool ElementExists(this ChromeDriver browser, By by)
        {
            try
            {
                browser.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
