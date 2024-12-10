using OpenQA.Selenium;
using ShoppingCart.Infrastructure.Enums;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class OrderPage
    {
        public IWebElement ContinueAsGuestButton => FindElement(By.XPath("//span[@class='btn-content' and text()='Continue as Guest']"));

        public IWebElement LicensesPrice => FindElement(By.XPath("//span[contains(@class, 'e2e-licenses-price')]"));

        public IWebElement MaintenancePrice => FindElement(By.XPath("//span[contains(@class, 'e2e-maintenance-price')]"));

        public IWebElement DiscountsPrice => FindElement(By.XPath("//span[contains(@class, 'e2e-total-discounts-price')]"));

        public IWebElement TotalPrice => FindElement(By.XPath("//h4[contains(@class, 'e2e-total-price')]"));

        public OrderPageRow GetRowBySkuId(SkuId skuId) => new OrderPageRow(skuId);
    }
}
