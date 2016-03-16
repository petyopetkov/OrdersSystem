namespace OrdersSystem.Common
{
    public class ValidationConstants
    {
        public const string DiviceDisplayName = "Device Name";
        public const string CustomerDisplayName = "Customer Name";
        public const string WorkerDisplayName = "Worker Name";
        public const string EndDateDisplayName = "End Date";
        public const string SupplierDisplayName = "Supplier Name";
        public const string DeviceCountDisplayName = "Device Count";
        public const string CategoryDisplayName = "Category";

        public const string DescriptionErrorMessage = "Description name must be between 3 and 2000 symbols";
        public const string DeviceCountErrorMessage = "Device count must be greater than 0";
        public const string CategoryNameErrorMessage = "Category name must be between 3 and 150 symbols";
        public const string DeviceNameErrorMessage = "Device name must be between 3 and 150 symbols";
        public const string SupplierNameErrorMessage = "Supplier name must be between 3 and 150 symbols";
        public const string CustomerNameErrorMessage = "Customer name must be between 3 and 150 symbols";
        public const string AddressErrorMessage = "Address must be between 3 and 500 symbols";

        public const int NameMinLength = 3;
        public const int NameMaxLength = 150;
        public const int DescriptionMinLength = 3;
        public const int DescriptionMaxLength = 2000;
        public const int DeviceCountMinRange = 1;
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 500;
    }
}
