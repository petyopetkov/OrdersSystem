namespace OrdersSystem.Web.Areas.Admin.ViewModels.Customers
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;
    using Models;
    using OrdersSystem.Common;
    
    public class CustomerInputModel : IMapTo<Customer>
    {
        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.AddressMinLength, ErrorMessage = ValidationConstants.AddressErrorMessage)]
        [MaxLength(ValidationConstants.AddressMaxLength, ErrorMessage = ValidationConstants.AddressErrorMessage)]
        [UIHint("TextArea")]
        public string Address { get; set; }
    }
}