using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Threading;
using WebShop.Web.Models.Layout;
using Abp;

namespace WebShop.Web.Controllers
{
    public class LayoutController : WebShopControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;

        public LayoutController(IUserNavigationManager userNavigationManager, ILocalizationManager localizationManager)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
        }

        [ChildActionOnly]
        public PartialViewResult TopMenu(string activeMenu = "")
        {
            UserIdentifier currentUser = UserIdentifier.Parse(AbpSession.UserId.ToString());
            TopMenuViewModel model = new TopMenuViewModel
                        {
                            MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenusAsync(currentUser)),
                            ActiveMenuItemName = activeMenu
                        };

            return PartialView("_TopMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            LanguageSelectionViewModel model = new LanguageSelectionViewModel
                        {
                            CurrentLanguage = _localizationManager.CurrentLanguage,
                            Languages = _localizationManager.GetAllLanguages()
                        };

            return PartialView("_LanguageSelection", model);
        }

        [ChildActionOnly]
        public PartialViewResult TopBar()
        {
            return PartialView("_TopBar", null);
        }

        [ChildActionOnly]
        public PartialViewResult TopBox()
        {
            return PartialView("_TopBox", null);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            return PartialView("_Footer", null);
        }
    }
}