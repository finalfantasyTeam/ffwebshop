using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using WebShop.EntityFramework;

namespace WebShop
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(WebShopCoreModule))]
    public class WebShopDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<WebShopDbContext>(null);
        }
    }
}
