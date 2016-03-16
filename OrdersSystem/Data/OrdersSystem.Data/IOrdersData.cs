namespace OrdersSystem.Data
{
    using System;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OrdersSystem.Models;
    using Repository;
    
    public interface IOrdersData : IDisposable
    {
        IRepository<User> Users { get; }

        RoleManager<IdentityRole> RolesManager { get; }

        UserManager<User> UserManager { get; }
    }
}
