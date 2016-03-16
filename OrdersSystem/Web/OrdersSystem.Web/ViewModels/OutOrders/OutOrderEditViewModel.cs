namespace OrdersSystem.Web.ViewModels.OutOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class OutOrderEditViewModel : IMapFrom<OutOrder>, IMapTo<OutOrder>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [UIHint("TextArea")]
        public string Description { get; set; }

        [Display(Name = ValidationConstants.WorkerDisplayName)]
        public string WorkerId { get; set; }

        [Display(Name = ValidationConstants.SupplierDisplayName)]
        public int SupplierId { get; set; }

        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }
        
        public OrderStatus Status { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }        

        public ICollection<SelectListItem> Suppliers { get; set; }
    }
}