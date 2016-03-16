namespace OrdersSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class OutOrder : Order
    {
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
