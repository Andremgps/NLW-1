using System.Collections.Generic;
using backend.Models;

namespace backend.Data.Abstract
{
    public interface IItemRepo
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        IEnumerable<Item> GetItemsByPointId(int id);
    }
}