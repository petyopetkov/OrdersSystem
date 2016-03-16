namespace OrdersSystem.Web.ViewModels.Repairs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Common;
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class RepairEditViewModel : IMapFrom<InOrder>, IMapTo<InOrder>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [UIHint("TextArea")]
        public string Description { get; set; }

        [Display(Name = ValidationConstants.WorkerDisplayName)]
        public string WorkerId { get; set; }

        [Display(Name = ValidationConstants.DiviceDisplayName)]
        public int DeviceId { get; set; }

        [Required]
        [Display(Name = ValidationConstants.DeviceCountDisplayName)]
        [Range(ValidationConstants.DeviceCountMinRange, int.MaxValue, ErrorMessage = ValidationConstants.DeviceCountErrorMessage)]
        public int DeviceCount { get; set; }

        [Display(Name = ValidationConstants.CustomerDisplayName)]
        public int CustomerId { get; set; }

        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }
        
        public OrderStatus Status { get; set; }

        public ICollection<SelectListItem> Devices { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }

        public ICollection<SelectListItem> Customers { get; set; }
    }
}