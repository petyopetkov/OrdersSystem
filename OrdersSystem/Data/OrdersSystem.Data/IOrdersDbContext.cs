namespace OrdersSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using OrdersSystem.Models;

    public interface IOrdersDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<InOrder> InOrders { get; set; }

        IDbSet<OutOrder> OutOrders { get; set; }

        IDbSet<Device> Devices { get; set; }

        IDbSet<Customer> Customers { get; set; }

        IDbSet<Supplier> Suppliers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
