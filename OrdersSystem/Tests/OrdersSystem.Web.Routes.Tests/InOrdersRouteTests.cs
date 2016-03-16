namespace OrdersSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    
    [TestFixture]
    public class InOrdersRouteTests
    {
        [Test]
        public void InOrdersTestRouteIndex()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/InOrders/Index";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<InOrdersController>(c => c.Index());
        }

        [Test]
        public void InOrdersTestRouteDetails()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/InOrders/Details/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<InOrdersController>(c => c.Details(1));
        }

        [Test]
        public void InOrdersTestRouteCreate()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/InOrders/Create";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<InOrdersController>(c => c.Create());
        }

        [Test]
        public void InOrdersTestRouteEdit()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/InOrders/Edit/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<InOrdersController>(c => c.Edit(1));
        }
    }
}
