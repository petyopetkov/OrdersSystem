namespace OrdersSystem.Web.Areas.Admin.ViewModels.Customers
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class CustomerEditModel : IMapFrom<Customer>, IMapTo<Customer>
    {
        public int Id { get; set; }

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