namespace OrdersSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class InOrder : Order
    {       
        [Range(ValidationConstants.DeviceCountMinRange, int.MaxValue, ErrorMessage = ValidationConstants.DeviceCountErrorMessage)]
        public int DeviceCount { get; set; }

        public bool IsRepair { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public string WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public virtual User Worker { get; set; }
    }
}