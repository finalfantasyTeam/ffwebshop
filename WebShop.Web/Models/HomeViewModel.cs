using System.Collections.Generic;
using System.Web.Security;
using WebShop.Application;

namespace WebShop.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public MembershipUser User { get; set; }
        public string PasswordHash { get; set; }
        public MembershipUserCollection ListUsers { get; set; }
        public IList<ProductDTO> ListProduct { get; set; }
    }
}