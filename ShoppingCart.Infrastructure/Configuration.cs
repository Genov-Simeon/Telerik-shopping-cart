using Microsoft.Extensions.Configuration;

namespace ShoppingCart.Infrastructure
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot _config;

        static Configuration()
        {
            var configFile = Directory.GetFiles(Directory.GetCurrentDirectory(), "appsettings.*.json").First();

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile, optional: false, reloadOnChange: true)
                .Build();
        }

        private static string Get(string key)
        {
            return _config[key];
        }

        public static string TelerikDomain => Get("TelerikDomain");

        public static string ShoppingCartDomain => Get("ShoppingCartDomain");

        public static string ShoppingCartURL => Get("ShoppingCartURL");

        public static string Browser => Get("Browser");

        public static string ProductBundlesUrl => Get("TelerikPurchasePage:ProductBundlesUrl");

        public static string IndividualProductsUrl => Get("TelerikPurchasePage:IndividualProductsUrl");

        public static string AddProductUrl => Get("AddProductUrl");
    }
}
