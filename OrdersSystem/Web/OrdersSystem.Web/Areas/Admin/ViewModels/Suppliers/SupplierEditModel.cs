namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class SupplierEditModel : IMapFrom<Supplier>, IMapTo<Supplier>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        public string Name { get; set; }
    }
}