using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Models;

namespace Axado.Repository.Mapping
{
    public class UserMap : EntityBaseMap<User>
    {
        public UserMap()
        {
            ToTable("USERS");

            Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Username)
                .HasColumnName("USERNAME")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
