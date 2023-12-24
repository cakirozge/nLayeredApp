using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;
//tabloda kötü isimlendirme yapılsa dahi kendi classımızda tablo isimlerini kendimiz verip onları düzeltebilirz.
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("ProductId").IsRequired();
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
        builder.Property(b => b.ProductName).HasColumnName("ProductName").IsRequired();
        builder.Property(b => b.UnitPrice).HasColumnName("UnitPrice");
        builder.Property(b => b.UnitsInStock).HasColumnName("UnitsInStock");
        builder.Property(b => b.QuantityPerUnit).HasColumnName("QuantityPerUnit");

        //IsUnique: Categorilerin isimlerinin tekrar edilmemesini sağlıyoruz.
        builder.HasIndex(indexExpression: b => b.ProductName, name: "UK_Products_ProductName").IsUnique();


        //bir productın bir categorysi olabilir.
        builder.HasOne(b => b.Category);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //default filtre veri tabaında where için
    }
}
