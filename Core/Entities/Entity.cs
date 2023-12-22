using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Entity<TId> : IEntityTimestamps //zaman damgası
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; } // -?: kullanıldığında içerisi boş olabilir zorunluluk içermez.
    public DateTime? DeletedDate { get; set; }
    public Entity() 
    { 
        Id = default; 
    }
    public Entity(TId id) //TId: generic yapıdır çünkü ıd:string gelebilir.
    { 
        Id = id; 
    }
}
