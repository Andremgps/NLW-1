namespace backend.Models
{
    public class Point_Item
    {
        public int Point_Id { get; set; }
        public int Item_Id { get; set; }

        public Point Point { get; set; }
        public Item Item { get; set; }
    }
}