using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Axado.Repository;
using Axado.Web.Models;

namespace Axado.Web.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var context = new Context();
            var user = (from p in context.Users
                       where p.Username.ToUpper() == viewModel.Username.ToUpper()
                          && p.Password == viewModel.Password
                      select p).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("", "User and/or password are incorrect.");
                return View(viewModel);
            }
            FormsAuthentication.SetAuthCookie(user.Id.ToString(), viewModel.Remember);
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Carriers");
        }

        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}