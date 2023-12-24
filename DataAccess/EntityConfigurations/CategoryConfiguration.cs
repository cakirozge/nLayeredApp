using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

//Configuraion: Veri tabanında hangi alanlar nasıl--- neye karşılık geleceğini kodladığımız yerdir.
//IEntityTypeConfiguration: sen categorynin entity tip varlık configurationısın implemente etmeyi unutma.
//+ Builder: categoriler tablosuna map olacaksın. ve alanlarını giriş yapacaksın.
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        
        builder.ToTable("Categories").HasKey(b=>b.Id);    

        builder.Property(b =>b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

        //IsUnique: Categorilerin isimlerinin tekrar edilmemesini sağlıyoruz.
        builder.HasIndex(indexExpression: b => b.Name , name: "UK_Categories_Name").IsUnique();


        //bir kategorinin birden çok ürünü olabilir aralarında bire çok ilişki vardır.
        builder.HasMany(b => b.Products);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //QueryFilter: default filtre uygulamak için.
    }
}





