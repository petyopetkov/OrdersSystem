namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface IOutOrdersServices
    {
        IQueryable<OutOrder> GetAll();

        OutOrder GetById(int id);

        OutOrder Create(OutOrder newOutOrder);

        OutOrder Update(int id, OutOrder outOrder);

        OutOrder UpdateStatus(int id, OutOrder outOrder);

        void DeleteById(int id);
    }
}
