namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;
    
    public interface ISuppliersServices
    {
        IQueryable<Supplier> GetAll();

        Supplier Add(Supplier supplier);

        Supplier Update(int id, Supplier supplier);

        void Delete(int id);
    }
}
