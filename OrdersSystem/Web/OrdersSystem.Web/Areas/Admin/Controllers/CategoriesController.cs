namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    using OrdersSystem.Services.Contracts;
    using ViewModels.Categories;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesServices categories;
        
        public CategoriesController(ICategoriesServices categoriesServices)
        {
            this.categories = categoriesServices;
        }

        public ActionResult Index()
        {
            var viewModel = this.categories.GetAll().To<CategoryViewModel>();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var categoryName = this.categories
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (categoryName == null)
                {
                    var category = this.Mapper.Map<Category>(model);
                    this.categories.Add(category);
                    TempData["Success"] = GlobalConstants.CategoryAddNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.CategoryExistsNotify;
                }                

                return this.Redirect("/Admin/Categories/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.categories
                .GetAll()
                .Where(x => x.Id == id)
                .To<CategoryEditModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var categoryName = this.categories
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (categoryName == null)
                {
                    var category = this.Mapper.Map<Category>(model);
                    this.categories.Update(model.Id, category);
                    TempData["Success"] = GlobalConstants.CategoryUpdateNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.CategoryExistsNotify;
                }

                return this.Redirect("/Admin/Categories/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.categories.Delete(id);
            TempData["Success"] = GlobalConstants.CategoryDeletedNotify;

            return this.Redirect("/Admin/Categories/Index");
        }
    }
}