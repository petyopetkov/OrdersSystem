namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;    
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
    using ViewModels.Users;
    using Web.Controllers;
    
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        public ActionResult Index()
        {
            var users = this.UsersServices.GetAll().To<UserViewModel>();

            return View(users);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = this.UsersServices.GetById(id);
            var viewModel = this.Mapper.Map<UserEditModel>(user);

            var userRoles = user.Roles.Select(r => r.RoleId);
            var userMissingRolesSelectListItems = this.RolesServices.All()
                .Where(r => !userRoles.Contains(r.Id))
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
                }).ToList();

            var userRolesSelectListItems = user.Roles.Select(r => new SelectListItem
            {
                Text = this.RolesServices.GetRoleNameById(r.RoleId),
                Value = r.RoleId
            })
            .ToList();

            ViewBag.RolesMissing = userMissingRolesSelectListItems;
            ViewBag.RolesAvailable = userRolesSelectListItems;

            return this.View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                this.UsersServices.Update(model.Id, model.Email);
                TempData["Success"] = "User email updated successfully.";
                return this.RedirectToAction("Index");
            }

            return this.View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoleToUser(string roleId, string userId)
        {
            if (ModelState.IsValid)
            {
                this.RolesServices.AddRoleToUser(userId, roleId);
                TempData["Success"] = "Role added to user";

                return RedirectToAction("Index");                
            }

            return this.View("Edit", userId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserRole(string roleId, string userId)
        {
            if (ModelState.IsValid)
            {
                this.RolesServices.RemoveUserRole(userId, roleId);
                TempData["Success"] = "Role removed from user";

                return RedirectToAction("Index");
            }

            return this.View("Edit", userId);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            this.UsersServices.Delete(id);

            return this.Redirect("/Admin/Users/Index");
        }
    }
}