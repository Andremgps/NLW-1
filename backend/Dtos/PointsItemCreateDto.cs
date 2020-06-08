using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class PointItemCreateDto
    {        
        [Required]
        public int Point_Id { get; set; }        
        [Required]
        public int Item_Id { get; set; }        
    }    
}