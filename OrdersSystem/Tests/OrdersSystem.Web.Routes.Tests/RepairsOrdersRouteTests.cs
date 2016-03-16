namespace OrdersSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    
    [TestFixture]
    public class RepairsOrdersRouteTests
    {
        [Test]
        public void RepairsTestRouteIndex()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/Repairs/Index";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<RepairsController>(c => c.Index());
        }

        [Test]
        public void RepairsTestRouteDetails()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/Repairs/Details/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<RepairsController>(c => c.Details(1));
        }

        [Test]
        public void RepairsTestRouteCreate()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/Repairs/Create";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<RepairsController>(c => c.Create());
        }

        [Test]
        public void RepairsTestRouteEdit()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/Repairs/Edit/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<RepairsController>(c => c.Edit(1));
        }
    }
}
