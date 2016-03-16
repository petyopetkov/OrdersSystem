namespace OrdersSystem.Web.Areas.Admin.ViewModels.Users
{
    using Infrastructure.Mapping;
    using Models;
    
    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}