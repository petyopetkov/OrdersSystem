namespace OrdersSystem.Web.ViewModels.OutOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class OutOrderInputModel : IMapTo<OutOrder>
    {
        [Required]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [UIHint("TextArea")]
        public string Description { get; set; }
        
        public string AuthorId { get; set; }
        
        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }
        
        public DateTime StartDate { get; set; }

        public OrderStatus Status { get; set; }
        
        [Display(Name = ValidationConstants.SupplierDisplayName)]
        public int SupplierId { get; set; }

        public ICollection<SelectListItem> Suppliers { get; set; }

        public ICollection<SelectListItem> Authors { get; set; }
    }
}