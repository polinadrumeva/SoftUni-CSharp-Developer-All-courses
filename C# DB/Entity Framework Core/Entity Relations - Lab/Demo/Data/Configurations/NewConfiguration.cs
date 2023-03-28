using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Configurations
{
    public class NewConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            
            builder.Property(x => x.Title)
                .HasColumnName("Title Of New")
                .HasMaxLength(50)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Content)
               .HasMaxLength(500)
               .HasColumnType("nvarchar")
               .IsRequired();

            
        }
    }
}
