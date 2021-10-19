using Domain.Entities.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Inventories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public Item FindById(int id)
        {
            Item[] items = FindAll();
            if(id <= 0)
            {
                throw new ArgumentException($"Error, Id: {id} no puede ser menor o igual a cero.");
            }

            if(items == null)
            {
                throw new Exception("Empty data.");
            }

            Item item = null;
            foreach(Item i in items)
            {
                if(i.Id == id)
                {
                    item = i;
                    break;
                }
            }

            return item;
        }
        public Item[] FindByProductId(int productId)
        {
            Item[] items = FindAll(), data = null;                        

            if (productId <= 0)
            {
                throw new ArgumentException($"Error, Id: {productId} no puede ser menor o igual a cero.");
            }

            if (items == null)
            {
                throw new Exception("Empty data.");
            }

            foreach(Item i in items)
            {
                if(i.Producto.Id == productId)
                {
                    Add(i, ref data);                    
                }
            }

            return data;
        }
    }
}
