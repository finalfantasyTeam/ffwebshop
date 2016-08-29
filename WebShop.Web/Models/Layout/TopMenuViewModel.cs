using Abp.Application.Navigation;
using System.Collections.Generic;

namespace WebShop.Web.Models.Layout
{
    public class TopMenuViewModel
    {
        public IReadOnlyList<UserMenu> MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}