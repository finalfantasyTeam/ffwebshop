using System.Web.Mvc;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AccountController : WebShopControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel viewModel)
        {
            return View(viewModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountViewModel viewModel)
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(AccountViewModel viewModel)
        {
            return View(viewModel);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(AccountViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}