namespace OrdersSystem.Services
{
    using System.Linq;

    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    
    public class CategoriesServices : ICategoriesServices
    {
        private IRepository<Category> categories;

        public CategoriesServices(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public Category Add(Category category)
        {
            this.categories.Add(category);
            this.categories.SaveChanges();

            return category;
        }

        public void Delete(int id)
        {
            this.categories.Delete(id);
            this.categories.SaveChanges();
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }

        public Category Update(int id, Category category)
        {
            var categoryToUpdate = this.categories.GetById(id);
            categoryToUpdate.Name = category.Name;
            this.categories.SaveChanges();

            return categoryToUpdate;
        }
    }
}
