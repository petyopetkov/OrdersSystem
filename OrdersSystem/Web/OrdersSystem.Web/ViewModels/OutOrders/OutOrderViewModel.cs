namespace OrdersSystem.Web.ViewModels.OutOrders
{    
    using System;
    using Infrastructure.Mapping;
    using Models;

    public class OutOrderViewModel : IMapFrom<OutOrder>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public OrderStatus Status { get; set; }

        public Supplier Supplier { get; set; }

        public User Author { get; set; }
    }
}