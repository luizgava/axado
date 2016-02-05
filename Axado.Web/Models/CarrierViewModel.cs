using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axado.Web.Models
{
    public class CarrierViewModel
    {
        public int Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string Url { get; set; }

        [Display(Name = "Rating average")]
        public double? RatingAvg { get; set; }

        public bool UserAlreadyRate { get; set; }
    }
}