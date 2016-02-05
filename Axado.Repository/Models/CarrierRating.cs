using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Repository.Models
{
    public class CarrierRating : EntityBase
    {
        public int Rating { get; set; }
        public int CarrierId { get; set; }
        public int UserId { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual User User { get; set; }
    }
}
