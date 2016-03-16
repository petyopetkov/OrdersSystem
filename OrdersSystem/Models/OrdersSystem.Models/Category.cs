namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Category
    {
        private ICollection<Device> devices;

        public Category()
        {
            this.devices = new HashSet<Device>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices
        {
            get { return this.devices; }
            set { this.devices = value; }
        }
    }
}
