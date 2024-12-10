using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Unity;

namespace ShoppingCart.Infrastructure
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; private set; }

        protected string BaseUrl { get; private set; }

        public WebDriverWait Wait { get; private set; }

        public Actions Actions { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            BaseUrl = Configuration.TelerikDomain;
            Wait = App.Container.Resolve<WebDriverWait>();
            Actions = new Actions(driver);
        }

        protected IWebElement FindElement(By by)
        {
            try
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NoSuchElementException($"Element with locator '{by}' was not found or did not become visible within the timeout period.", ex);
            }
        }

        protected IWebElement FindElementToBeClickable(By by)
        {
            try
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException ex)
            {

                throw new NoSuchElementException($"Element with locator '{by}' was not found or did not become clickable within the timeout period.", ex);
            }
        }
    }
} 