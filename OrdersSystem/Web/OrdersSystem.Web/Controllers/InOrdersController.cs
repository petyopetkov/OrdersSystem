namespace OrdersSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Microsoft.AspNet.Identity;
    using Models;    
    using Ninject;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using OrdersSystem.Web.ViewModels.InOrders;

    public class InOrdersController : BaseController
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        [Inject]
        public ICustomersServices CustomersSurvices { get; set; }

        [Inject]
        public IDevicesServices DevicesServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        public ActionResult Index()
        {
            var inOrders = InOrdersServices
                .GetAll()
                .Where(x => x.IsRepair == false)
                .To<InOrderViewModel>();

            return View(inOrders);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        public ActionResult Details(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            if (inOrder == null)
            {
                return this.View("Error");
            }

            var viewModel = this.Mapper.Map<InOrderViewModel>(inOrder);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new InOrderInputModel();
            viewModel.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            viewModel.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
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
        public ActionResult Create(InOrderInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.IsRepair = false;
                model.StartDate = DateTime.Now;
                model.AuthorId = User.Identity.GetUserId();
                var newInOrder = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Create(newInOrder);

                TempData["Success"] = GlobalConstants.InOrderCreateNotify;
                return this.RedirectToAction("Index");
            }

            return this.View(model);            
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            if (inOrder == null)
            {
                return this.View("Error");
            }

            var viewModel = this.Mapper.Map<InOrderEditViewModel>(inOrder);

            viewModel.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            viewModel.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
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
        public ActionResult Edit(InOrderEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var inOrder = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Update(model.Id, inOrder);
                TempData["Success"] = GlobalConstants.InOrderUpdateNotify;
                return this.RedirectToAction("Details", new { id = model.Id });
            }

            return this.View(model);           
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        [HttpGet]
        public ActionResult GetFullDescription(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            if (inOrder == null)
            {
                return this.View("Error");
            }

            var description = inOrder.Description;

            return this.Content(description);
        }

        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        [HttpPost]
        public ActionResult UpdateStatus(int id, InOrderViewModel model)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            if (inOrder == null)
            {
                return this.View("Error");
            }

            inOrder.Status = model.Status;
            this.InOrdersServices.UpdateStatus(id, inOrder);
            var content = model.Status;
            return this.Content(content.ToString());
        }
    }
}