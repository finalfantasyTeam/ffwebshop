using System.Web.Mvc;
using System.Web.Security;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class AccountController : WebShopControllerBase
    {
        public AccountController()
        {
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel viewModel, string returlUrl)
        {
            if (Membership.ValidateUser(viewModel.CurrentUser.UserName, viewModel.UserMembership.Password))
            {
                if (string.IsNullOrEmpty(returlUrl))
                {
                    FormsAuthentication.RedirectFromLoginPage(viewModel.CurrentUser.UserName, false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(viewModel.CurrentUser.UserName, false);
                }
            }

            return View(viewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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