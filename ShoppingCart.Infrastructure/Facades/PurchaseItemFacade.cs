using ShoppingCart.Infrastructure.Enums;
using ShoppingCart.Infrastructure.Pages;

namespace ShoppingCart.Infrastructure
{
   public class PurchaseItemFacade
   {
        public PurchasePage PurchasePage { get; set; }

        public OrderPage OrderPage { get; set; }

        public PurchaseItemFacade(PurchasePage purchasePage, OrderPage orderPage)
        {
            PurchasePage = purchasePage;
            OrderPage = orderPage;
        }

        public void AddProductToCart(SkuId skuId)
        {
            PurchasePage.NavigateToProductBundles();
            PurchasePage.GetProductBuyNowButton(skuId.GetDescription().Replace("DevCraft", "").Trim()).Click();
            OrderPage.WaitUntilPageIsLoaded();
        }
    }
}
