using System;
using System.Collections.Generic;
using System.Linq;
using backend.Data.Abstract;
using backend.Models;

namespace backend.Data.Repositories
{
    public class SqlPointRepo : IPointRepo
    {
        private readonly DatabaseContext _context;

        public SqlPointRepo(DatabaseContext context)
        {
            _context = context;
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDbTransaction(_context);
        }

        public void CreatePoint(Point point)
        {
            if(point == null){
                throw new ArgumentNullException(nameof(point));
            }
            _context.Points.Add(point);            
        }

        public void CreatePointItems(List<Point_Item> pointItems)
        {
            if(pointItems == null){
                throw new ArgumentNullException(nameof(pointItems));
            }
            _context.Point_Item.AddRange(pointItems);
        }

        public IEnumerable<Point> GetFilteredPoints(string city, string uf, List<int> items)
        {            
            return (
                from point in _context.Points
                join point_item in _context.Point_Item on point.Id equals point_item.Point_Id
                where (
                    items.Contains(point_item.Item_Id) &&
                    point.City == city &&
                    point.Uf == uf
                )                
                select point
            ).Distinct().ToList();
        }

        public Point GetPointById(int id)
        {
            return _context.Points.FirstOrDefault(point => point.Id == id);
        }        

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}