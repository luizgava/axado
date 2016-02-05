using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Models;

namespace Axado.Repository.Infra
{
    public class AxadoCustomInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Users.Add(new User { Username = "AXADO", Password = "axado", Name = "Axado Administrator", CreationDate = DateTime.Now });
            base.Seed(context);
        }
    }
}
