namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface IInOrdersServices
    {
        IQueryable<InOrder> GetAll();

        InOrder GetById(int id);

        InOrder Create(InOrder newOutOrder);

        InOrder Update(int id, InOrder outOrder);

        InOrder UpdateStatus(int id, InOrder inOrder);

        void DeleteById(int id);
    }
}
