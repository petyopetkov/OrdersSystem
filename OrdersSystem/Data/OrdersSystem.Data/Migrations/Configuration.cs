namespace OrdersSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<OrdersDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OrdersDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedCategories(context);
            this.SeedDevices(context);
            this.SeedCustomers(context);
        }

        private void SeedRoles(OrdersDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = "Admin" };
                roleManager.Create(adminRole);

                context.SaveChanges();
            }
        }

        private void SeedUsers(OrdersDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var admin = new User()
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com"
                };

                userManager.Create(admin, "123456");
                userManager.AddToRole(admin.Id, "Admin");

                var worker = new User()
                {
                    Email = "pesho@pesho.com",
                    UserName = "pesho@pesho.com"
                };

                var worker2 = new User()
                {
                    Email = "georgi@georgi.com",
                    UserName = "georgi@georgi.com"
                };

                var worker3 = new User()
                {
                    Email = "hristo@hristo.com",
                    UserName = "hristo@hristo.com"
                };

                var workerRole = roleManager.Create(new IdentityRole("Worker"));

                userManager.Create(worker, "123456");
                userManager.AddToRole(worker.Id, "Worker");
                userManager.Create(worker2, "123456");
                userManager.AddToRole(worker2.Id, "Worker");
                userManager.Create(worker3, "123456");
                userManager.AddToRole(worker3.Id, "Worker");

                var boss = new User()
                {
                    Email = "misho@misho.com",
                    UserName = "misho@misho.com"
                };

                var boss2 = new User()
                {
                    Email = "evgeni@evgeni.com",
                    UserName = "evgeni@evgeni.com"
                };

                var bossRole = roleManager.Create(new IdentityRole("Boss"));

                userManager.Create(boss, "123456");
                userManager.AddToRole(boss.Id, "Boss");
                userManager.Create(boss2, "123456");
                userManager.AddToRole(boss2.Id, "Boss");

                context.SaveChanges();
            }
        }

        private void SeedCategories(OrdersDbContext context)
        {
            string[] categories = new string[] { "Indicators", "Controllers", "Transmitters", "Gas Alarms" };
            if (!context.Categories.Any())
            {
                for (int i = 0; i < 4; i++)
                {
                    var category = new Category()
                    {
                        Name = categories[i]
                    };

                    context.Categories.Add(category);
                }

                context.SaveChanges();
            }
        }

        private void SeedDevices(OrdersDbContext context)
        {
            string[] indicators = new string[] { "4002", "4003", "4004", "4007" };
            string[] controllers = new string[] { "4006", "2002", "6002", "3002" };
            string[] transmitters = new string[] { "DI-DPT", "SP-410L", "SP-520L", "RHT-RS" };
            string[] gasAlarms = new string[] { "DG-910", "DG-510", "DG-2000", "OXY meter" };
            if (!context.Devices.Any())
            {
                for (int i = 0; i < 4; i++)
                {
                    var indicator = new Device()
                    {
                        Name = indicators[i],
                        CategoryId = 1
                    };
                    context.Devices.Add(indicator);

                    var controller = new Device()
                    {
                        Name = controllers[i],
                        CategoryId = 2
                    };
                    context.Devices.Add(controller);

                    var transmitter = new Device()
                    {
                        Name = transmitters[i],
                        CategoryId = 3
                    };
                    context.Devices.Add(transmitter);

                    var gas = new Device()
                    {
                        Name = gasAlarms[i],
                        CategoryId = 4
                    };
                    context.Devices.Add(gas);
                }

                context.SaveChanges();
            }
        }

        private void SeedCustomers(OrdersDbContext context)
        {
            if (!context.Customers.Any())
            {
                string[] customers = new string[] { "Delektra", "Enemona", "Tasi", "Sofiiska voda", "Bulgargas" };
                for (int i = 0; i < 5; i++)
                {
                    var customer = new Customer()
                    {
                        Name = customers[i],
                        Address = "Address " + i
                    };

                    context.Customers.Add(customer);
                }

                context.SaveChanges();
            }
        }
    }
}
