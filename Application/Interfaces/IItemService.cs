using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IItemService : IService<Item>
    {
        Item FindById(int id);
        Item[] FindByProductId(int productId);
    }
}
