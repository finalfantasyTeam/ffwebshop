using System.Reflection;
using Abp.Modules;

namespace WebShop
{
    [DependsOn(typeof(WebShopCoreModule))]
    public class WebShopApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
