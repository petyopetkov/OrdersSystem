namespace OrdersSystem.Services
{
    using System.Linq;

    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    
    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

        public void Delete(string id)
        {
            this.users.Delete(id);
            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All().OrderBy(x => x.UserName);
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public User Update(string id, string email)
        {
            var user = this.users.GetById(id);
            
            user.Email = email;
            user.UserName = email;

            this.users.SaveChanges();
            return user;
        }
    }
}
