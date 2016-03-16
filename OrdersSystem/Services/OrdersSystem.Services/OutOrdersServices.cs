namespace OrdersSystem.Services
{
    using System;
    using System.Linq;

    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    
    public class OutOrdersServices : IOutOrdersServices
    {
        private IRepository<OutOrder> outOrders;

        public OutOrdersServices(IRepository<OutOrder> outOrders)
        {
            this.outOrders = outOrders;
        }

        public IQueryable<OutOrder> GetAll()
        {
            return this.outOrders.All().OrderByDescending(x => x.Id);
        }

        public OutOrder GetById(int id)
        {
            return this.outOrders.GetById(id);
        }
        
        public OutOrder Update(int id, OutOrder outOrder)
        {
            var outOrderToUpdate = this.outOrders.GetById(id);
            outOrderToUpdate.Description = outOrder.Description;
            outOrderToUpdate.Status = outOrder.Status;
            outOrderToUpdate.EndDate = outOrder.EndDate;
            outOrderToUpdate.SupplierId = outOrder.SupplierId;
            outOrderToUpdate.AuthorId = outOrder.AuthorId;

            this.outOrders.SaveChanges();
            return outOrder;
        }

        public OutOrder Create(OutOrder newOutOrder)
        {
            this.outOrders.Add(newOutOrder);
            this.outOrders.SaveChanges();
            return newOutOrder;
        }

        public void DeleteById(int id)
        {
            this.outOrders.Delete(id);
        }

        public OutOrder UpdateStatus(int id, OutOrder outOrder)
        {
            var outOrderToUpdate = this.outOrders.GetById(id);
            outOrderToUpdate.Status = outOrder.Status;

            this.outOrders.SaveChanges();

            return outOrderToUpdate;
        }
    }
}
