using NUnit.Framework;
using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Utilities;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class OrderPage
    {
        public void AssertPricesCalculatedCorrectly(OrderPagePrices pagePrices)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(pagePrices.LicensesPrice, LicensesPrice.Text.ExctractPrice(), "Licenses price does not match.");
                Assert.AreEqual(pagePrices.MaintenancePrice, MaintenancePrice.Text.ExctractPrice(), "Maintenance price does not match.");
                Assert.AreEqual(pagePrices.DiscountsPrice, DiscountsPrice.Text.ExctractPrice(), "Discounts price does not match.");
                Assert.AreEqual(pagePrices.TotalPrice, TotalPrice.Text.ExctractPrice(), "Total price does not match.");
            });
        }
    }
}
