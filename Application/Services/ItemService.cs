using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ItemService : BaseService<Item>, IItemService
    {
        private IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository) : base(itemRepository)
        {
            this.itemRepository = itemRepository;
        }
       
        public Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Item[] FindByProductId(int productId)
        {
            return itemRepository.FindByProductId(productId);
        }

    }
}
