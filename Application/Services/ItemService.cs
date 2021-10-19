using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void Create(Item t)
        {
            itemRepository.Create(t);
        }

        public bool Delete(Item t)
        {
            throw new NotImplementedException();
        }

        public Item[] FindAll()
        {
            return itemRepository.FindAll();
        }

        public Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Item[] FindByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            return itemRepository.GetLastId();
        }

        public int Update(Item t)
        {
            throw new NotImplementedException();
        }
    }
}
