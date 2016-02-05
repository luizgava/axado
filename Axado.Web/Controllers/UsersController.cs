using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axado.Repository;
using Axado.Repository.Models;
using Axado.Web.Models;

namespace Axado.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            var context = new Context();
            var users = (from p in context.Users
                         orderby p.Name
                         select new UserViewModel
                         {
                             Name = p.Name,
                             Id = p.Id,
                             Username = p.Username
                         }).ToList();

            return View(users);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                var user = new User
                {
                    Name = viewModel.Name,
                    Username = viewModel.Username.ToUpper(),
                    Password = viewModel.Password
                };

                context.Users.Add(user);
                var exists = (from p in context.Users
                              where p.Username.ToUpper() == viewModel.Username
                              select p).Any();
                if (exists)
                {
                    throw new Exception($"There is already a registered user with the username {user.Username}.");
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var context = new Context();
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"Usuário com código {id} não encontrado.");
            }
            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Password = user.Password
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                var user = context.Users.FirstOrDefault(x => x.Id == viewModel.Id);
                if (user == null)
                {
                    throw new Exception($"User with id {viewModel.Id} not found.");
                }
                user.Username = viewModel.Username;
                user.Name = viewModel.Name;
                if (!string.IsNullOrWhiteSpace(viewModel.Password))
                {
                    user.Password = viewModel.Password;
                }
                try
                {
                    var exists = (from p in context.Users
                                  where p.Username.ToUpper() == user.Username
                                     && p.Id != user.Id
                                  select p).Any();
                    if (exists)
                    {
                        throw new Exception($"There is already a registered user with the username {user.Username}.");
                    }

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception exp)
                {
                    ModelState.AddModelError("", exp.Message);
                }
            }
            return View(viewModel);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            var context = new Context();
            var user = (from p in context.Users
                        where p.Id == id
                        select p).FirstOrDefault();
            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            if (user.Id == 1)
            {
                throw new Exception("You can not delete the user id 1.");
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}