using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IProductRepository : IRepository<Producto>
    {
        Producto FindAny(Predicate<Producto> predicate);
        ICollection<Producto> FindAll(Predicate<Producto> predicate);
    }
}
