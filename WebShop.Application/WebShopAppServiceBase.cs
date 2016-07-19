using Abp.Application.Services;

namespace WebShop
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WebShopAppServiceBase : ApplicationService
    {
        protected WebShopAppServiceBase()
        {
            LocalizationSourceName = WebShopConsts.LocalizationSourceName;
        }
    }
}