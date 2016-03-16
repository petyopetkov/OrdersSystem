namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Supplier
    {
        private ICollection<OutOrder> outOrders;

        public Supplier()
        {
            this.outOrders = new HashSet<OutOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        public string Name { get; set; }

        public virtual ICollection<OutOrder> OutOrders
        {
            get { return this.outOrders; }
            set { this.outOrders = value; }
        }
    }
}