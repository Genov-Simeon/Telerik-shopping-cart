using ShoppingCart.Infrastructure;
using ShoppingCart.Infrastructure.Enums;
using ShoppingCart.Infrastructure.Pages;

namespace ShoppingCart.Tests
{
    public class ShoppingCartTests : BaseTest
    {
        [Test]
        public void ProductAddedToCart_When_AddSingleProductThroughUrl()
        {
            AddProductToCart(SkuId.DevCraftUi);

            var devCraftUIRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUi);

            Assert.That(devCraftUIRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUi.GetDescription()));
        }

        [Test]
        public void ProductAddedToCart_When_AddSingleProductThroughUi()
        {
            PurchaseItemFacade.AddProductToCart(SkuId.DevCraftUi);

            var devCraftUIRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUi);

            Assert.That(devCraftUIRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUi.GetDescription()));
        }

        [Test]
        public void ProductsAddedToCart_When_AddMultipleProductsThroughUi()
        {
            PurchaseItemFacade.AddProductToCart(SkuId.DevCraftUi);
            PurchaseItemFacade.AddProductToCart(SkuId.DevCraftComplete);
            PurchaseItemFacade.AddProductToCart(SkuId.DevCraftUltimate);

            var devCraftUIRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUi);
            var devCraftCompleteRow = OrderPage.GetRowBySkuId(SkuId.DevCraftComplete);
            var devCraftUltimateRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUltimate);

            Assert.Multiple(() =>
            {
                Assert.That(devCraftUIRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUi.GetDescription()));
                Assert.That(devCraftCompleteRow.RowName.Text, Is.EqualTo(SkuId.DevCraftComplete.GetDescription()));
                Assert.That(devCraftUltimateRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUltimate.GetDescription()));
            });
        }

        [Test]
        public void ProductsAddedToCart_When_AddMultipleProductsThroughUrl()
        {
            AddProductToCart(SkuId.DevCraftUi);
            AddProductToCart(SkuId.DevCraftComplete);
            AddProductToCart(SkuId.DevCraftUltimate);

            var devCraftUIRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUi);
            var devCraftCompleteRow = OrderPage.GetRowBySkuId(SkuId.DevCraftComplete);
            var devCraftUltimateRow = OrderPage.GetRowBySkuId(SkuId.DevCraftUltimate);

            Assert.Multiple(() =>
            {
                Assert.That(devCraftUIRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUi.GetDescription()));
                Assert.That(devCraftCompleteRow.RowName.Text, Is.EqualTo(SkuId.DevCraftComplete.GetDescription()));
                Assert.That(devCraftUltimateRow.RowName.Text, Is.EqualTo(SkuId.DevCraftUltimate.GetDescription()));
            });
        }
    }
} 