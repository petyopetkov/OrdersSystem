namespace OrdersSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}