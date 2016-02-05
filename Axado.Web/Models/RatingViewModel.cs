using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axado.Web.Models
{
    public class RatingViewModel
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        [Required]
        public int? Rating { get; set; }
    }
}