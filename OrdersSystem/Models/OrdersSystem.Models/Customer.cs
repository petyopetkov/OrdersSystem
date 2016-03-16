namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Customer
    {
        private ICollection<InOrder> inOrders;

        public Customer()
        {
            this.inOrders = new HashSet<InOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(ValidationConstants.AddressMinLength, ErrorMessage = ValidationConstants.AddressErrorMessage)]
        [MaxLength(ValidationConstants.AddressMaxLength, ErrorMessage = ValidationConstants.AddressErrorMessage)]
        public string Address { get; set; }
        
        public virtual ICollection<InOrder> InOrders
        {
            get { return this.inOrders; }
            set { this.inOrders = value; }
        }
    }
}
