namespace OrdersSystem.Services
{
    using System;
    using System.Linq;
    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;

    public class CustomersServices : ICustomersServices
    {
        private IRepository<Customer> customers;

        public CustomersServices(IRepository<Customer> customers)
        {
            this.customers = customers;
        }

        public Customer Add(Customer customer)
        {
            this.customers.Add(customer);
            this.customers.SaveChanges();

            return customer;
        }

        public void Delete(int id)
        {
            this.customers.Delete(id);
            this.customers.SaveChanges();
        }

        public IQueryable<Customer> GetAll()
        {
            return this.customers.All().OrderBy(x => x.Name);
        }

        public Customer Update(int id, Customer customer)
        {
            var customerToUpdate = this.customers.GetById(id);
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Address = customer.Address;
            this.customers.SaveChanges();

            return customerToUpdate;
        }
    }
}
