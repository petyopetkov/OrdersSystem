namespace OrdersSystem.Web.Areas.Admin.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;

    public class UserEditModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [UIHint("String")]
        public string Email { get; set; }        
    }
}