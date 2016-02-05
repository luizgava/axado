using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axado.Repository.Models;
using Axado.Web.Models;

namespace Axado.Web.Util
{
    public static class Extensions
    {
        public static IQueryable<CarrierViewModel> ToCarrierViewModel(this IQueryable<Carrier> query)
        {
            var userId = HttpContext.Current.User.Identity.IsAuthenticated ? int.Parse(HttpContext.Current.User.Identity.Name) : 0;
            return from p in query
                   select new CarrierViewModel
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Identification = p.Identification,
                       Url = p.Url,
                       State = p.State,
                       City = p.City,
                       Adress = p.Adress,
                       PhoneNumber = p.PhoneNumber,
                       Country = p.Country,
                       RatingAvg = p.CarrierRatings.Average(x => x.Rating),
                       UserAlreadyRate = p.CarrierRatings.Any(x => x.UserId == userId)
                   };
        }
    }
}