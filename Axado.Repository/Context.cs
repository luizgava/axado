using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Infra;
using Axado.Repository.Mapping;
using Axado.Repository.Models;

namespace Axado.Repository
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Context : DbContext
    {
        public Context() : base("AxadoCS")
        {
            
        }

        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierRating> CarrierRating { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(new AxadoCustomInitializer());

            modelBuilder.Configurations.Add(new CarrierMap());
            modelBuilder.Configurations.Add(new CarrierRatingMap());
            modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
