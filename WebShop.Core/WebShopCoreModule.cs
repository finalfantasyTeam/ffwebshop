using System.Reflection;
using Abp.Modules;

namespace WebShop
{
    public class WebShopCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
