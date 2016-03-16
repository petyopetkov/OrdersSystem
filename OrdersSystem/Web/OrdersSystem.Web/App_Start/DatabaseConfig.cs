namespace OrdersSystem.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrdersDbContext, Configuration>());
            OrdersDbContext.Create().Database.Initialize(true);
        }
    }
}