using Abp.Web.Mvc.Controllers;

namespace WebShop.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class WebShopControllerBase : AbpController
    {
        protected WebShopControllerBase()
        {
            LocalizationSourceName = WebShopConsts.LocalizationSourceName;
        }
    }
}