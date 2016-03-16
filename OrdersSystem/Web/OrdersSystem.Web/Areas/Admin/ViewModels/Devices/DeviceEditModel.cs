namespace OrdersSystem.Web.Areas.Admin.ViewModels.Devices
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class DeviceEditModel : IMapFrom<Device>, IMapTo<Device>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        public string Name { get; set; }

        [Required]
        [Display(Name = ValidationConstants.CategoryDisplayName)]
        public int CategoryId { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }
    }
}