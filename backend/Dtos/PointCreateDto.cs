using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class PointCreateDto
    {        
        [Required]
        public string Image { get; set; }        
        [Required]
        public string Name { get; set; }        
        [Required]
        public string Email { get; set; }        
        [Required]
        public string Whatsapp { get; set; }        
        [Required]
        public decimal Latitude { get; set; }        
        [Required]
        public decimal Longitude { get; set; }        
        [Required]
        public string City { get; set; }                
        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }   
        public List<int> Items { get; set; }     
    }    
}