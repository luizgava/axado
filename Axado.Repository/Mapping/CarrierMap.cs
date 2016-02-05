using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Models;

namespace Axado.Repository.Mapping
{
    public class CarrierMap : EntityBaseMap<Carrier>
    {
        public CarrierMap()
        {
            ToTable("CARRIERS");

            Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Adress)
                .HasColumnName("ADRESS")
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.City)
                .HasColumnName("CITY")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Country)
                .HasColumnName("COUNTRY")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Identification)
                .HasColumnName("IDENTIFICATION")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.PhoneNumber)
                .HasColumnName("PHONENUMBER")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.State)
                .HasColumnName("STATE")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Url)
                .HasColumnName("URL")
                .HasMaxLength(100)
                .IsRequired();

            HasMany(x => x.CarrierRatings)
                .WithOptional()
                .HasForeignKey(x => x.CarrierId)
                .WillCascadeOnDelete(true);
        }
    }
}
