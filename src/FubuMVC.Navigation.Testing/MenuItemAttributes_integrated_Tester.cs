using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.StructureMap;
using NUnit.Framework;
using System.Linq;
using FubuTestingSupport;

namespace FubuMVC.Navigation.Testing
{
    [TestFixture]
    public class MenuItemAttributes_integrated_Tester
    {

        [Test]
        public void puts_the_navigation_graph_in_the_right_order()
        {
            var registry = new FubuRegistry();
            registry.Actions.IncludeType<Controller1>();

            using (var runtime = FubuApplication.For(registry).StructureMap().Bootstrap())
            {
                var resolver = runtime.Factory.Get<IMenuResolver>();

                resolver.MenuFor(new NavigationKey("Root")).AllNodes().Select(x => x.Key.Key)
                    .ShouldHaveTheSameElementsAs("Three", "Two", "One", "Four");

                runtime.Factory.Get<NavigationGraph>()
                    .FindNode(new NavigationKey("Two")).ShouldBeOfType<MenuNode>().Previous.Key.Key.ShouldEqual("Three");

            }


        }

        public class Controller1
        {
            [MenuItem("One", AddChildTo = "Two")]
            public void One(Input1 input){}

            [MenuItem("Two", AddChildTo = "Root")]
            public void Two(Input1 input){}

            [MenuItem("Three", AddBefore = "Two")]
            public void Three(Input1 input){}

            [MenuItem("Four", AddChildTo = "Root")]
            public void Four(Input1 input) { }


            public class Input1 { }
        }
    }

    
}