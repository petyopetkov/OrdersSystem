namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoriesServices
    {
        IQueryable<Category> GetAll();

        Category Add(Category category);

        Category Update(int id, Category category);

        void Delete(int id);
    }
}
