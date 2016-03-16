namespace OrdersSystem.Web.ViewModels.InOrders
{
    using System;

    using Infrastructure.Mapping;
    using Models;
    
    public class InOrderViewModel : IMapFrom<InOrder>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public int DeviceCount { get; set; }
        
        public OrderStatus Status { get; set; }

        public Device Device { get; set; }

        public User Author { get; set; }

        public User Worker { get; set; }

        public Customer Customer { get; set; }
    }
}