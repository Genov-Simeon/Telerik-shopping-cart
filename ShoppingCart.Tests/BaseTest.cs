using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using Unity;
using ShoppingCart.Infrastructure.Pages;
using ShoppingCart.Infrastructure;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace ShoppingCart.Tests
{
    public class BaseTest
    {
        public IWebDriver? Driver { get; set; }

        public Actions Actions { get; set; }

        public string Browser { get; set; }

        protected ContactInfoPage ContactInfoPage { get; set; }

        protected OrderPage OrderPage { get; set; }

        protected PurchasePage PurchasePage { get; set; }

        protected ConfigurePurchasePage ConfigurePurchasePage { get; set; }

        protected ReviewOrderPage ReviewOrderPage { get; set; }

        protected PurchaseItemFacade PurchaseItemFacade { get; set; }

        [SetUp]
        public void OneTimeSetUp()
        {
            Browser = Configuration.Browser;
            switch (Browser)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "Edge":
                    var edgeOptions = new EdgeOptions();
                    Driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Browser '{Browser}' is not supported.");
            }

            App.Container.RegisterInstance(Driver);
            App.Container.RegisterInstance(new WebDriverWait(Driver, TimeSpan.FromSeconds(10)));

            Actions = App.Container.Resolve<Actions>();

            ContactInfoPage = App.Container.Resolve<ContactInfoPage>();
            OrderPage = App.Container.Resolve<OrderPage>();
            PurchasePage = App.Container.Resolve<PurchasePage>();
            ConfigurePurchasePage = App.Container.Resolve<ConfigurePurchasePage>();
            ReviewOrderPage = App.Container.Resolve<ReviewOrderPage>();

            PurchaseItemFacade = App.Container.Resolve<PurchaseItemFacade>();

            SetConsentCookies();
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }

        private void SetConsentCookies()
        {
            var utcNowDate = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
            Cookie optanonAlertBoxClosed = new Cookie("OptanonAlertBoxClosed", utcNowDate);
            Driver.Navigate().GoToUrl(Configuration.TelerikDomain + "/robots.txt");
            Driver.Manage().Cookies.AddCookie(optanonAlertBoxClosed);
            Driver.Navigate().GoToUrl(Configuration.ShoppingCartDomain + "/robots.txt");
            Driver.Manage().Cookies.AddCookie(optanonAlertBoxClosed);
        }

        public void AddProductToCart(Enum skuId, int quantity = 1)
        {
            var productId = skuId.ToString("d");
            for (int i = 0; i < quantity; i++)
            {
                Driver.Navigate().GoToUrl(Configuration.AddProductUrl + productId);
                OrderPage.WaitUntilPageIsLoaded();
            }
        }

        public void AddIndividualProductToCart(Enum individualSkuId, int quantity = 1)
        {
            var productId = individualSkuId.ToString("d");
            for (int i = 0; i < quantity; i++)
            {
                Driver.Navigate().GoToUrl(Configuration.AddProductUrl + productId);
                ConfigurePurchasePage.ContinueButton.Click();
            }
        }
    }
}
