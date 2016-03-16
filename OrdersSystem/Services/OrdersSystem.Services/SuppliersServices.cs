namespace OrdersSystem.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repository;
    using Models;
    
    public class SuppliersServices : ISuppliersServices
    {
        private IRepository<Supplier> suppliers;

        public SuppliersServices(IRepository<Supplier> suppliers)
        {
            this.suppliers = suppliers;
        }

        public Supplier Add(Supplier supplier)
        {
            this.suppliers.Add(supplier);
            this.suppliers.SaveChanges();

            return supplier;
        }

        public void Delete(int id)
        {
            this.suppliers.Delete(id);
            this.suppliers.SaveChanges();
        }

        public IQueryable<Supplier> GetAll()
        {
            return this.suppliers.All().OrderBy(s => s.Name);
        }

        public Supplier Update(int id, Supplier supplier)
        {
            var supplierToUpdate = this.suppliers.GetById(id);
            supplierToUpdate.Name = supplier.Name;
            this.suppliers.SaveChanges();

            return supplierToUpdate;
        }
    }
}
