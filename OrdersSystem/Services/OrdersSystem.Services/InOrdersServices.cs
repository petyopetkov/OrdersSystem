namespace OrdersSystem.Services
{
    using System.Linq;

    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;    

    public class InOrdersServices : IInOrdersServices
    {
        private IRepository<InOrder> inOrders;

        public InOrdersServices(IRepository<InOrder> inOrders)
        {
            this.inOrders = inOrders;
        }

        public InOrder Create(InOrder newInOrder)
        {
            this.inOrders.Add(newInOrder);
            this.inOrders.SaveChanges();

            return newInOrder;
        }

        public void DeleteById(int id)
        {
            this.inOrders.Delete(id);
        }

        public IQueryable<InOrder> GetAll()
        {
            return this.inOrders.All().OrderByDescending(x => x.Id);
        }

        public InOrder GetById(int id)
        {
            return this.inOrders.GetById(id);
        }

        public InOrder Update(int id, InOrder inOrder)
        {
            var inOrderToUpdate = this.inOrders.GetById(id);
            inOrderToUpdate.Description = inOrder.Description;
            inOrderToUpdate.CustomerId = inOrder.CustomerId;
            inOrderToUpdate.DeviceId = inOrder.DeviceId;
            inOrderToUpdate.DeviceCount = inOrder.DeviceCount;
            inOrderToUpdate.Status = inOrder.Status;
            inOrderToUpdate.EndDate = inOrder.EndDate;
            inOrderToUpdate.WorkerId = inOrder.WorkerId;

            this.inOrders.SaveChanges();

            return inOrderToUpdate;
        }

        public InOrder UpdateStatus(int id, InOrder inOrder)
        {
            var inOrderToUpdate = this.inOrders.GetById(id);
            inOrderToUpdate.Status = inOrder.Status;

            this.inOrders.SaveChanges();

            return inOrderToUpdate;
        }
    }
}
