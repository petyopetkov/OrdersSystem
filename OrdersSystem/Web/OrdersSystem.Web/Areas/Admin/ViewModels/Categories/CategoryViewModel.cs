namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}