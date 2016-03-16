namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;

    public class SupplierViewModel : IMapFrom<Supplier>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}