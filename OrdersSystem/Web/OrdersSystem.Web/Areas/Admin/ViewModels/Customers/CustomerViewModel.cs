namespace OrdersSystem.Web.Areas.Admin.ViewModels.Customers
{
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;

    public class CustomerViewModel : IMapFrom<Customer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}