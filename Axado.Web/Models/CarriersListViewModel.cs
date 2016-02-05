using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axado.Web.Models
{
    public class CarriersListViewModel
    {
        public List<CarrierViewModel> Carriers { get; set; }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public string Search { get; set; }
    }
}