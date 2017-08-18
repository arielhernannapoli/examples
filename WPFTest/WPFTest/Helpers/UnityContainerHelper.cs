using Microsoft.Practices.Unity;

namespace WPFTest
{
    public static class UnityContainerHelper
    {
        public static Microsoft.Practices.Unity.UnityContainer GetContainer()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );
            return container;
        }
    }
}
