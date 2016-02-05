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

        [StringLength(50)]
        public string Identification { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Adress { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [Display(Name = "Phone number")]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        [Display(Name = "Rating average")]
        public double? RatingAvg { get; set; }

        public bool UserAlreadyRate { get; set; }
    }
}