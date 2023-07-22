using RestaurantApp.BL.DTOs;
using RestaurantApp.BL.DTOs.Items;
using RestaurantApp.DAL.Data.Models;
using RestaurantApp.DAL.Repos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    public class ItemsManager : IItemsManager
    {
        private readonly IItemtsReop itemRepo;

        public ItemsManager(IItemtsReop itemRepo)
        {
            this.itemRepo = itemRepo;
        }
        public IEnumerable<ItemReadDto> GetItems()
        {
            var itemsfromdb = itemRepo.GetItems();
            return itemsfromdb.Select(i => new ItemReadDto
            {
                Id = i.Id,
                name=i.Name,
                category=i.Category,
                price=i.price,
                description=i.Description,
                image=i.image
            });
        }
        public ItemReadDto? GetItemById(int id)
        {
            Item? itemfromdb = itemRepo.GetItemById(id);
            if (itemfromdb == null) return null;
            return new ItemReadDto
            {
                Id = itemfromdb.Id,
                name = itemfromdb.Name,
                category = itemfromdb.Category,
                price = itemfromdb.price,
                description = itemfromdb.Description,
                image = itemfromdb.image
            };
        }

        public IEnumerable<ItemReadDto>? GetItemByCategory(string category)
        {
            var itemfromdb = itemRepo.GetItemByCategory(category);
            if (itemfromdb == null) return null;
            return itemfromdb.Select(i => new ItemReadDto
            {
                Id = i.Id,
                name = i.Name,
                category = i.Category,
                price = i.price,
                description = i.Description,
                image = i.image
            });
        }


        public int AddItem(ItemAddDto item)
        {
            Item itemtodb = new Item
            {
                Name = item.name,
                Category = item.category,
                price = item.price,
                Description = item.description,
                image = item.image
            };
            itemRepo.AddItem(itemtodb);
            itemRepo.saveChanges();
            return itemtodb.Id;
        }

        public int deleteItem(int id)
        {
            Item? itemtofind = itemRepo.GetItemById(id);
            if (itemtofind == null) return 0;
            itemRepo.deleteItem(itemtofind);
            itemRepo.saveChanges();
            return 1;
        }

       
    }
}
