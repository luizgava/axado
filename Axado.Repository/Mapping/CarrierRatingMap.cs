using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Models;

namespace Axado.Repository.Mapping
{
    public class CarrierRatingMap : EntityBaseMap<CarrierRating>
    {
        public CarrierRatingMap()
        {
            ToTable("CARRIERRATINGS");

            Property(x => x.Rating)
                .HasColumnName("RATING")
                .IsRequired();

            Property(x => x.CarrierId)
                .HasColumnName("IDCARRIER")
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("IDUSER")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            HasRequired(x => x.Carrier)
                .WithMany()
                .HasForeignKey(x => x.CarrierId)
                .WillCascadeOnDelete(true);
        }
    }
}
