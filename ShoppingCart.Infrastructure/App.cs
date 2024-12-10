using Unity;

namespace ShoppingCart.Infrastructure
{
    public static class App
    {
        public static IUnityContainer Container { get; set; }

        static App()
        {
            Container = new UnityContainer();
        }
    }
}
