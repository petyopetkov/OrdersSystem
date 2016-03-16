namespace OrdersSystem.Common
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";
        public const string WorkerRoleName = "Worker";
        public const string BossRoleName = "Boss";

        public const string InOrderCreateNotify = "Incoming order created";
        public const string InOrderUpdateNotify = "Incoming order updated";

        public const string OutOrderCreateNotify = "Outgoing order created";
        public const string OutOrderUpdateNotify = "Outgoing order updated";

        public const string RepairOrderCreateNotify = "Repair order created";
        public const string RepairOrderUpdateNotify = "Repair order updated";

        public const string DeviceAddNotify = "Device added";
        public const string DeviceUpdateNotify = "Device updated";
        public const string DeviceExistsNotify = "Device already exists";
        public const string DeviceDeletedNotify = "Device deleted";

        public const string CategoryUpdateNotify = "Category updated";
        public const string CategoryAddNotify = "Category added";
        public const string CategoryExistsNotify = "Category already exists";
        public const string CategoryDeletedNotify = "Category deleted";

        public const string SupplierAddNotify = "Supplier added";
        public const string SupplierExistsNotify = "Supplier already exists";
        public const string SupplierUpdatedNotify = "Supplier updated";
        public const string SupplierDeletedNotify = "Supplier deleted";

        public const string CustomerAddNotify = "Customer added";
        public const string CustomerExistsNotify = "Customer already exists";
        public const string CustomerUpdateNotify = "Customer updated";
        public const string CustomerDeletedNotify = "Customer deleted";
    }
}
