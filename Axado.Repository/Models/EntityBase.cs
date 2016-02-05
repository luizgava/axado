using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axado.Repository.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public void Create()
        {
            CreationDate = DateTime.Now;
        }

        public void Update()
        {
            UpdateDate = DateTime.Now;
        }
    }
}