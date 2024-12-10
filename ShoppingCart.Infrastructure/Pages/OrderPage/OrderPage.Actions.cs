using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Configuration.ShoppingCartURL);
        }

        public void WaitUntilPageIsLoaded()
        {
            Wait.Until(driver => ContinueAsGuestButton.Displayed);
        }
    }
}
