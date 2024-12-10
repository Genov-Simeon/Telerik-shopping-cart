using ShoppingCart.Infrastructure.Enums;
using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Pages;
using ShoppingCart.Infrastructure.Utilities;

namespace ShoppingCart.Tests
{
    public class PriceCalculationTests : BaseTest
    {
        private OrderPageRow _rowDevCraftUi;
        private OrderPageRow _rowDevCraftComplete;
        private decimal _licensePriceDevCraftUi;
        private decimal _licensePriceDevCraftComplete;

        [SetUp]
        public void SetUp()
        {
            AddProductToCart(SkuId.DevCraftUi, 1);
            AddProductToCart(SkuId.DevCraftComplete, 1);
            _rowDevCraftUi = OrderPage.GetRowBySkuId(SkuId.DevCraftUi);
            _rowDevCraftComplete = OrderPage.GetRowBySkuId(SkuId.DevCraftComplete);

            _licensePriceDevCraftUi = _rowDevCraftUi.LicensePrice.Text.ExctractPrice();
            _licensePriceDevCraftComplete = _rowDevCraftComplete.LicensePrice.Text.ExctractPrice();
        }

        [TestCase(2, 5, 2, 3)]
        [TestCase(3, 4, 4, 5)]
        [TestCase(6, 9, 2, 3)]
        [TestCase(7, 29, 4, 5)]
        [Test]
        public void PricesUpdatedCorrectly_When_ChangeLicense_And_MaintenanceQuantity(int firstProductLicenseQuantity, int secondProductLicenseQuantity, int firstProductMaintenanceQuantity,  int secondProductMaintenanceQuantity)
        {
            _rowDevCraftUi.EnterQuantityOfLicenses(firstProductLicenseQuantity);
            _rowDevCraftUi.EnterYearsOfMaintenanceAndSupport(firstProductMaintenanceQuantity);
            _rowDevCraftComplete.EnterQuantityOfLicenses(secondProductLicenseQuantity);
            _rowDevCraftComplete.EnterYearsOfMaintenanceAndSupport(secondProductMaintenanceQuantity);

            var rowPricesDevCraftUi = CalculateLicenseAndTermPrices(_licensePriceDevCraftUi, firstProductLicenseQuantity, firstProductMaintenanceQuantity);
            var rowPricesDevCraftComplete = CalculateLicenseAndTermPrices(_licensePriceDevCraftComplete, secondProductLicenseQuantity, secondProductMaintenanceQuantity);
            var pagePrices = CalculatePagePrices(rowPricesDevCraftUi, rowPricesDevCraftComplete);

            Assert.Multiple(() =>
            {
                _rowDevCraftUi.AssertRowPrices(rowPricesDevCraftUi);
                _rowDevCraftComplete.AssertRowPrices(rowPricesDevCraftComplete);
                OrderPage.AssertPricesCalculatedCorrectly(pagePrices);
            });
        }

        private OrderPagePrices CalculatePagePrices(params OrderPageRowPrices[] rowPrices)
        {
            var pagePrices = new OrderPagePrices();

            foreach (OrderPageRowPrices rowPrice in rowPrices)
            {
                pagePrices.LicensesPrice += (rowPrice.LicensePrice + rowPrice.LicenseSavePrice) * rowPrice.LicenseQuantity;
                pagePrices.MaintenancePrice += (rowPrice.TermPrice + rowPrice.TermSavePrice) * (rowPrice.MaintenanceQuantity - 1);
                pagePrices.DiscountsPrice += rowPrice.LicenseSavePrice * rowPrice.LicenseQuantity + rowPrice.TermSavePrice * (rowPrice.MaintenanceQuantity - 1);
            }

            pagePrices.TotalPrice = pagePrices.LicensesPrice + pagePrices.MaintenancePrice - pagePrices.DiscountsPrice;

            return pagePrices;
        }

        private OrderPageRowPrices CalculateLicenseAndTermPrices(decimal licensePrice, int licenseQuantity, int maintenanceQuantity)
        {
            decimal maintenancePrice = Math.Floor(licensePrice / 2m);
            decimal licenseSavePrice = 0;
            decimal termPrice = Math.Floor(licensePrice / 2m);
            decimal termSavePrice = 0;
            decimal subtotal = 0;

            if (licenseQuantity >= 2 && licenseQuantity <= 5)
            {
                licenseSavePrice = Math.Round(0.05m * licensePrice, 2);
                licensePrice = Math.Round(licensePrice - 0.05m * licensePrice, 2);
                maintenancePrice = Math.Round(0.95m * maintenancePrice * licenseQuantity, 2);

                if (maintenanceQuantity == 2)
                {
                    termSavePrice = Math.Round(0.08m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 3)
                {
                    termSavePrice = Math.Round(0.11m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 4)
                {
                    termSavePrice = Math.Round(0.14m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 5)
                {
                    termSavePrice = Math.Round(0.17m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
            }
            else if (licenseQuantity >= 6)
            {
                licenseSavePrice = Math.Round(0.1m * licensePrice, 2);
                licensePrice = Math.Round(licensePrice - 0.1m * licensePrice, 2);
                maintenancePrice = Math.Round((maintenancePrice - 0.1m * maintenancePrice) * licenseQuantity, 2);
                
                if (maintenanceQuantity == 2)
                {
                    termSavePrice = Math.Round(0.13m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 3)
                {
                    termSavePrice = Math.Round(0.16m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 4)
                {
                    termSavePrice = Math.Round(0.19m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
                else if (maintenanceQuantity == 5)
                {
                    termSavePrice = Math.Round(0.22m * termPrice, 2);
                    termPrice = Math.Round(termPrice - termSavePrice, 2);
                }
            }

            termPrice *= licenseQuantity;
            termSavePrice *= licenseQuantity;
            subtotal = licensePrice * licenseQuantity + termPrice * (maintenanceQuantity - 1);

            return new OrderPageRowPrices
            {
                LicenseQuantity = licenseQuantity,
                MaintenanceQuantity = maintenanceQuantity,
                LicensePrice = licensePrice,
                LicenseSavePrice = licenseSavePrice,
                MaintenancePrice = maintenancePrice,
                TermPrice = termPrice,
                TermSavePrice = termSavePrice,
                SubTotalPrice = subtotal,
            };
        }
    }
}
