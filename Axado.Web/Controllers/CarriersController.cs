using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axado.Repository;
using Axado.Repository.Models;
using Axado.Web.Models;
using Axado.Web.Util;

namespace Axado.Web.Controllers
{
    [Authorize]
    public class CarriersController : Controller
    {
        #region Index
        [AllowAnonymous]
        public ActionResult Index(string search, int? page)
        {
            var context = new Context();
            var carriers = from p in context.Carriers
                           select p;

            if (!string.IsNullOrWhiteSpace(search))
            {
                carriers = from p in carriers
                           where p.Name.ToLower().Contains(search.ToLower())
                              || p.Identification.ToLower().Contains(search.ToLower())
                           select p;
            }
            page = page.GetValueOrDefault(1);
            var pageIndex = page.Value - 1;
            var itemsPage = 25;

            carriers = carriers.OrderBy(x => x.Name);

            var viewModel = new CarriersListViewModel();
            viewModel.Page = page.Value;
            viewModel.Search = search;
            viewModel.Carriers = (carriers.ToCarrierViewModel().Skip(pageIndex * itemsPage).Take(itemsPage)).ToList();
            viewModel.TotalPages = (int)Math.Ceiling((double)carriers.Count() / itemsPage);

            return View(viewModel);
        }

        public ActionResult _Pagination()
        {
            return PartialView();
        }
        #endregion

        #region Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var context = new Context();
            var carrier = (from p in context.Carriers
                           where p.Id == id
                           select p).ToCarrierViewModel().FirstOrDefault();
            if (carrier == null)
            {
                return RedirectToAction("Index");
            }
            return View(carrier);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarrierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var carrier = new Carrier
                {
                    Name = viewModel.Name,
                    Adress = viewModel.Adress,
                    City = viewModel.City,
                    Country = viewModel.Country,
                    Identification = viewModel.Identification,
                    PhoneNumber = viewModel.PhoneNumber,
                    State = viewModel.State,
                    Url = viewModel.Url
                };
                var context = new Context();
                carrier.Create();
                context.Carriers.Add(carrier);
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
            var carrier = (from p in context.Carriers
                           where p.Id == id
                           select p).ToCarrierViewModel().FirstOrDefault();
            if (carrier == null)
            {
                return RedirectToAction("Index");
            }
            return View(carrier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarrierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                var carrier = context.Carriers.First(x => x.Id == viewModel.Id);
                carrier.Name = viewModel.Name;
                carrier.Adress = viewModel.Adress;
                carrier.City = viewModel.City;
                carrier.Country = viewModel.Country;
                carrier.Identification = viewModel.Identification;
                carrier.PhoneNumber = viewModel.PhoneNumber;
                carrier.State = viewModel.State;
                carrier.Url = viewModel.Url;
                carrier.Update();
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            var context = new Context();
            var carrier = context.Carriers.FirstOrDefault(x => x.Id == id);
            if (carrier == null)
            {
                return RedirectToAction("Index");
            }
            context.Carriers.Remove(carrier);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}