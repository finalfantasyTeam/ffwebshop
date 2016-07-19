using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace WebShop
{
    [DependsOn(typeof(AbpWebApiModule), typeof(WebShopApplicationModule))]
    public class WebShopWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(WebShopApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
