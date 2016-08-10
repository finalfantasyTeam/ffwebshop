using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ProductManufactoryManagementController : AdminControllerBase
    {

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            ProductManufactoryViewModel viewModel = new ProductManufactoryViewModel();
            await viewModel.FillDataForModel();

            return View(viewModel);
        }
    }
}