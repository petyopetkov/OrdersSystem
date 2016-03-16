namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    using Services.Contracts;
    using ViewModels.Suppliers;
    using Web.Controllers;
    
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class SuppliersController : BaseController
    {
        private readonly ISuppliersServices suppliers;

        public SuppliersController(ISuppliersServices suppliersServices)
        {
            this.suppliers = suppliersServices;
        }

        public ActionResult Index()
        {
            var viewModel = this.suppliers
                .GetAll()
                .To<SupplierViewModel>();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SupplierInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var supplierName = this.suppliers
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (supplierName == null)
                {
                    var supplier = this.Mapper.Map<Supplier>(model);
                    this.suppliers.Add(supplier);
                    TempData["Success"] = GlobalConstants.SupplierAddNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.SupplierExistsNotify;
                }

                return this.Redirect("/Admin/Suppliers/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.suppliers
                .GetAll()
                .Where(x => x.Id == id)
                .To<SupplierEditModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var supplierName = this.suppliers
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (supplierName == null)
                {
                    var supplier = this.Mapper.Map<Supplier>(model);
                    this.suppliers.Update(model.Id, supplier);
                    TempData["Success"] = GlobalConstants.SupplierUpdatedNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.SupplierExistsNotify;
                }

                return this.Redirect("/Admin/Suppliers/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.suppliers.Delete(id);
            TempData["Success"] = GlobalConstants.SupplierDeletedNotify;

            return this.Redirect("/Admin/Suppliers/Index");
        }
    }
}