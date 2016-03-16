namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;
    
    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User Update(string id, string email);

        void Delete(string id);
    }
}
