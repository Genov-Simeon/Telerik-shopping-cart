namespace ShoppingCart.Infrastructure.Models
{
    public class OrderPageRowPrices
    {
        public int LicenseQuantity { get; set; }

        public int MaintenanceQuantity { get; set; }

        public decimal LicensePrice { get; set; }

        public decimal LicenseSavePrice { get; set; }

        public decimal MaintenancePrice { get; set; }

        public decimal TermPrice { get; set; }

        public decimal TermSavePrice { get; set; }

        public decimal SubTotalPrice { get; set; }
    }
}
