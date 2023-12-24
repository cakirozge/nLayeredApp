using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Product:Entity<int> //Guid: veritabanın attığında string döner. Guid: sayı ve harf olusturan bir veri tipidir.veri güvenliğimizi sağlar.
{
    //mapleme yapacağımız için Category'nin Idsi ile Product'ın Idsini aynı zamanda elimizda bulunsun diye alttaki adımı yaptık.
    public int? CategoryId { get; set; }
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public string? QuantityPerUnit { get; set; }
    public Category Category { get; set; } //* category class ile product classı arasında bire çok ilişkisi vardır.
}
