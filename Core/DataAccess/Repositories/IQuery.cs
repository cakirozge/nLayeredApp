using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    //EF birden fazla query birleştirip baska bir veri tabanında calıstırmamızı sağlar
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
