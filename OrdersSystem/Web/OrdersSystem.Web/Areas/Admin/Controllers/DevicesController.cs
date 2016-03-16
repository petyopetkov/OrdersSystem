namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Models;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using ViewModels.Devices;
    using Web.Controllers;
    
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class DevicesController : BaseController
    {
        private readonly ICategoriesServices categories;
        private readonly IDevicesServices devices;

        public DevicesController(IDevicesServices devicesServices, ICategoriesServices categoriesServices)
        {
            this.categories = categoriesServices;
            this.devices = devicesServices;
        }

        public ActionResult Index()
        {
            var viewModel = this.devices
               .GetAll()
               .To<DeviceViewModel>();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new DeviceInputModel();
            viewModel.Categories = this.categories
                .GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DeviceInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var deviceName = this.devices
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (deviceName == null)
                {
                    var newDevice = this.Mapper.Map<Device>(model);
                    this.devices.Add(newDevice);

                    TempData["Success"] = GlobalConstants.DeviceAddNotify;                    
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.DeviceExistsNotify;
                }

                return this.Redirect("/Admin/Devices/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.devices
                .GetAll()
                .Where(x => x.Id == id)
                .To<DeviceEditModel>()
                .FirstOrDefault();

            viewModel.Categories = this.categories
                .GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeviceEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var deviceName = this.devices
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (deviceName == null)
                {
                    var device = this.Mapper.Map<Device>(model);
                    this.devices.Update(model.Id, device);
                    TempData["Success"] = GlobalConstants.DeviceUpdateNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.DeviceExistsNotify;
                }

                return this.Redirect("/Admin/Devices/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.devices.Delete(id);
            TempData["Success"] = GlobalConstants.DeviceDeletedNotify;

            return this.Redirect("/Admin/Devices/Index");
        }
    }
}