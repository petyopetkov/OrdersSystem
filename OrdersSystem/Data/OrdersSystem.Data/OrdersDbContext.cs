namespace OrdersSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OrdersSystem.Models;

    public class OrdersDbContext : IdentityDbContext<User>, IOrdersDbContext
    {
        public OrdersDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Device> Devices { get; set; }

        public virtual IDbSet<InOrder> InOrders { get; set; }

        public virtual IDbSet<OutOrder> OutOrders { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Supplier> Suppliers { get; set; }

        public static OrdersDbContext Create()
        {
            return new OrdersDbContext();
        }
    }
}
