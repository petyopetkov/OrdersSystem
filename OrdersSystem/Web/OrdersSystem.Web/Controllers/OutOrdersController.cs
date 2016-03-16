namespace OrdersSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Services.Contracts;
    using ViewModels.OutOrders;

    public class OutOrdersController : BaseController
    {
        [Inject]
        public IOutOrdersServices OutOrdersServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public ISuppliersServices SuppliersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        public ActionResult Index()
        {
            var outOrders = this.OutOrdersServices
                .GetAll()
                .To<OutOrderViewModel>();

            return View(outOrders);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            if (outOrder == null)
            {
                return this.View("Error");
            }

            var viewModel = this.Mapper.Map<OutOrderViewModel>(outOrder);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Create()
        {
            var newOrder = new OutOrderInputModel();

            newOrder.Suppliers = this.SuppliersServices
                .GetAll()
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
                .ToList();            

            return this.View(newOrder);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutOrderInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.StartDate = DateTime.Now;
                model.AuthorId = User.Identity.GetUserId();
                var newOutOrder = this.Mapper.Map<OutOrder>(model);
                this.OutOrdersServices.Create(newOutOrder);

                TempData["Success"] = GlobalConstants.OutOrderCreateNotify;
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            if (outOrder == null)
            {
                return this.View("Error");
            }

            var viewModel = this.Mapper.Map<OutOrderEditViewModel>(outOrder);

            viewModel.Suppliers = this.SuppliersServices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            var workerRoleId = this.RolesServices.GetRoleId(GlobalConstants.WorkerRoleName);

            viewModel.Workers = this.UsersServices
                .GetAll()
                .Where(w => w.Roles.Any(x => x.RoleId == workerRoleId))
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OutOrderEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var outOrder = this.Mapper.Map<OutOrder>(model);
                this.OutOrdersServices.Update(model.Id, outOrder);

                TempData["Success"] = GlobalConstants.OutOrderUpdateNotify;
                return this.RedirectToAction("Details", new { id = model.Id });
            }

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        [HttpGet]
        public ActionResult GetFullDescription(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            if (outOrder == null)
            {
                return this.View("Error");
            }

            var description = outOrder.Description;

            return this.Content(description);
        }

        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        [HttpPost]
        public ActionResult UpdateStatus(int id, OutOrderViewModel model)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            if (outOrder == null)
            {
                return this.View("Error");
            }

            outOrder.Status = model.Status;
            this.OutOrdersServices.UpdateStatus(id, outOrder);
            var content = model.Status;
            return this.Content(content.ToString());
        }
    }
}