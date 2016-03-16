namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Device
    {
        private ICollection<InOrder> inOrders;

        public Device()
        {
            this.inOrders = new HashSet<InOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<InOrder> InOrders
        {
            get { return this.inOrders; }
            set { this.inOrders = value; }
        }
    }
}