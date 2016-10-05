using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class CustomerController : WebShopControllerBase
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}