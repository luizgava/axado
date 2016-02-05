using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axado.Repository.Models;

namespace Axado.Repository.Mapping
{
    public class EntityBaseMap<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public EntityBaseMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CreationDate)
                .HasColumnName("CREATIONDATE")
                .IsRequired();

            Property(x => x.UpdateDate)
                .HasColumnName("UPDATEDATE");
        }
    }
}
