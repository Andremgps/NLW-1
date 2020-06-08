using System.Collections.Generic;
using System.Linq;
using backend.Data.Abstract;
using backend.Models;

namespace backend.Data.Repositories
{
    public class SqlItemRepo : IItemRepo
    {
        private readonly DatabaseContext _context;

        public SqlItemRepo(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Item> GetItemsByPointId(int pointId)        
        {
            return (
                from item in _context.Items
                join point_item in _context.Point_Item on item.Id equals point_item.Item_Id
                where (point_item.Point_Id  == pointId)
                select item
            ).ToList();            
        }
    }
}