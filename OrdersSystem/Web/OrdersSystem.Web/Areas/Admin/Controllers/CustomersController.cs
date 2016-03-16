namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    using OrdersSystem.Web.Controllers;
    using Services.Contracts;
    using ViewModels.Customers;
    
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CustomersController : BaseController
    {
        private readonly ICustomersServices customers;

        public CustomersController(ICustomersServices customersServices)
        {
            this.customers = customersServices;
        }

        public ActionResult Index()
        {
            var viewModel = this.customers.GetAll().To<CustomerViewModel>();
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CustomerInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var customerName = this.customers
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (customerName == null)
                {
                    var customer = this.Mapper.Map<Customer>(model);
                    this.customers.Add(customer);
                    TempData["Success"] = GlobalConstants.CustomerAddNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.CustomerExistsNotify;
                }

                return this.Redirect("/Admin/Customers/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.customers
                .GetAll()
                .Where(x => x.Id == id)
                .To<CustomerEditModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var customer = this.Mapper.Map<Customer>(model);
                this.customers.Update(model.Id, customer);
                TempData["Success"] = GlobalConstants.CustomerUpdateNotify;
                
                return this.Redirect("/Admin/Customers/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.customers.Delete(id);
            TempData["Success"] = GlobalConstants.CustomerDeletedNotify;

            return this.Redirect("/Admin/Categories/Index");
        }
    }
}