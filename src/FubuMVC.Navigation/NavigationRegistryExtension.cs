using FubuMVC.Core;

namespace FubuMVC.Navigation
{
    public class NavigationRegistryExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Global.Add<MenuItemAttributeConfigurator>();

            registry.Services<NavigationServiceRegistry>();
        }
    }
}