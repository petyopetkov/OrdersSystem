namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface ICustomersServices
    {
        IQueryable<Customer> GetAll();

        Customer Add(Customer customer);

        Customer Update(int id, Customer customer);

        void Delete(int id);
    }
}
