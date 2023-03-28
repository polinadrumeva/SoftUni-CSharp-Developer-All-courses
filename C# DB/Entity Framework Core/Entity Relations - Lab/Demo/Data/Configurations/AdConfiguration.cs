using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            
            builder.Property(x => x.Title)
                 .HasMaxLength(50)
                 .HasColumnType("varchar")
                 .IsRequired();

            builder.Property(x => x.Content)
               .HasMaxLength(500)
               .HasColumnType("varchar");
        }
    }
}
