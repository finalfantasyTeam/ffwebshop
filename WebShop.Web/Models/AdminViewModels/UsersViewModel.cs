using System.Web.Security;

namespace WebShop.Web.Models
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
        }

        public MembershipUser User { get; set; }
        public string PasswordHash { get; set; }
        public MembershipUserCollection ListUsers { get; set; }
    }
}