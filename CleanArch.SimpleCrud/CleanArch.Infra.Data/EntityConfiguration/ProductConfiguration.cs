using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasData(
                    new Product
                    {
                        Id = 1, 
                        Name = "Caderno",
                        Description = "Caderno 1",
                        Price = 9.45m
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Caderno merreca",
                        Description = "Caderno 2",
                        Price = 15.45m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Caderno meia boca",
                        Description = "Caderno 3",
                        Price = 19.45m
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Caderno top",
                        Description = "Caderno 4",
                        Price = 69.45m
                    }
                );
        }
    }
}
