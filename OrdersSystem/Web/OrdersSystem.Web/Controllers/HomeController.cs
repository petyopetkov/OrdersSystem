namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Ninject;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using ViewModels.InOrders;

    public class HomeController : BaseController
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1 * 60)]
        [ChildActionOnly]
        public ActionResult CacheHome()
        {
            var inOrders = this.InOrdersServices
                .GetAll()
                .Where(x => x.IsRepair == false)
                .OrderByDescending(x => x.EndDate)
                .Take(6)
                .To<InOrderViewModel>()
                .ToList();

            return this.PartialView("_CacheHomePartial", inOrders);
        }       
    }
}