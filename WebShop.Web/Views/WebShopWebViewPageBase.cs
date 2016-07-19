using Abp.Web.Mvc.Views;

namespace WebShop.Web.Views
{
    public abstract class WebShopWebViewPageBase : WebShopWebViewPageBase<dynamic>
    {

    }

    public abstract class WebShopWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WebShopWebViewPageBase()
        {
            LocalizationSourceName = WebShopConsts.LocalizationSourceName;
        }
    }
}