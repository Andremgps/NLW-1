using System.Collections.Generic;
using backend.Models;

namespace backend.Data.Abstract
{
    public interface IPointRepo
    {
        IDatabaseTransaction BeginTransaction();
        bool SaveChanges();
        Point GetPointById(int id);        
        IEnumerable<Point> GetFilteredPoints(string city, string uf, List<int> items);
        void CreatePoint(Point point);
        void CreatePointItems(List<Point_Item> pointItems);
    }
}