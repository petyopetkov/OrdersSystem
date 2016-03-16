namespace OrdersSystem.Data
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OrdersSystem.Data.Repository;
    using OrdersSystem.Models;
    
    public class OrdersData : IOrdersData
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private OrdersDbContext context;
        
        public OrdersData()
            : this(new OrdersDbContext())
        {
        }

        public OrdersData(OrdersDbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public RoleManager<IdentityRole> RolesManager
        {
            get
            {
                var roleStore = new RoleStore<IdentityRole>(this.context);
                var rolesManager = new RoleManager<IdentityRole>(roleStore);
                return rolesManager;
            }
        }

        public UserManager<User> UserManager
        {
            get
            {
                var userStore = new UserStore<User>(this.context);
                var userManager = new UserManager<User>(userStore);
                return userManager;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
