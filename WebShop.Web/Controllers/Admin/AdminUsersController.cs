using System;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers.Admin
{
    public class AdminUsersController : AdminControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.ListUsers = Membership.GetAllUsers();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.User = Membership.GetUser(id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UsersViewModel viewModel = new UsersViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.User = Membership.GetUser(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UsersViewModel viewModel)
        {
            MembershipUser newUser = Membership.CreateUser(viewModel.User.UserName, viewModel.PasswordHash);
            return RedirectToAction("Details", new { id = newUser.ProviderUserKey });
        }

        [HttpPost]
        public ActionResult Update(UsersViewModel viewModel)
        {
            Membership.UpdateUser(viewModel.User);
            return RedirectToAction("Details", new { id = viewModel.User.ProviderUserKey });
        }
    }
}