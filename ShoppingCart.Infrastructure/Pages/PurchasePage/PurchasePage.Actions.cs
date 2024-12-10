using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class PurchasePage : BasePage
    {
        public PurchasePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Configuration.ShoppingCartURL);
        }

        public void NavigateToProductBundles()
        {
            Driver.Navigate().GoToUrl(Configuration.ProductBundlesUrl);
        }

        public void NavigateToIndividualProducts()
        {
            Driver.Navigate().GoToUrl(Configuration.IndividualProductsUrl);
        }
    }
}
