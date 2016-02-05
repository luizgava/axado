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
    public class RatingsController : Controller
    {
        #region Create
        public ActionResult Create(int id)
        {
            var context = new Context();
            var carrier = (from p in context.Carriers
                            where p.Id == id
                            select p).FirstOrDefault();
            if (carrier == null)
            {
                return RedirectToAction("Index", "Carriers");
            }
            var viewModel = new RatingViewModel
            {
                CarrierId = carrier.Id,
                CarrierName = carrier.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var rating = new CarrierRating
                {
                    CarrierId = viewModel.CarrierId,
                    UserId = userId,
                    Rating = viewModel.Rating.Value
                };
                var context = new Context();
                rating.Create();
                context.CarrierRating.Add(rating);
                context.SaveChanges();

                return RedirectToAction("Index", "Carriers");
            }
            return View(viewModel);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var context = new Context();
            var viewModel = (from r in context.CarrierRating
                             join c in context.Carriers on r.CarrierId equals c.Id
                            where r.CarrierId == id
                               && r.UserId == userId
                             select new RatingViewModel
                             {
                                 CarrierId = r.CarrierId,
                                 CarrierName = c.Name,
                                 Rating = r.Rating
                             }).FirstOrDefault();
            if (viewModel == null)
            {
                return RedirectToAction("Index", "Carriers");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var context = new Context();
                var rating = context.CarrierRating .FirstOrDefault(x => x.CarrierId == viewModel.CarrierId && x.UserId == userId);
                if (rating == null)
                {
                    return RedirectToAction("Index", "Carriers");
                }
                rating.Rating = viewModel.Rating.Value;
                rating.Update();
                context.SaveChanges();

                return RedirectToAction("Index", "Carriers");
            }
            return View(viewModel);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var context = new Context();
            var rating = context.CarrierRating.FirstOrDefault(x => x.CarrierId == id && x.UserId == userId);
            if (rating == null)
            {
                return RedirectToAction("Index", "Carriers");
            }
            context.CarrierRating.Remove(rating);
            context.SaveChanges();

            return RedirectToAction("Index", "Carriers");
        }
        #endregion
    }
}