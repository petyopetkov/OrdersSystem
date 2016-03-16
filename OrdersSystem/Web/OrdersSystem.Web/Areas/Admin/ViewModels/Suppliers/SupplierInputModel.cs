namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class SupplierInputModel : IMapTo<Supplier>
    {
        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        public string Name { get; set; }
    }
}