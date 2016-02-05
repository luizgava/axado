using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Repository.Models
{
    public class Carrier : EntityBase
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Url { get; set; }

        public IList<CarrierRating> CarrierRatings { get; set; }
    }
}
