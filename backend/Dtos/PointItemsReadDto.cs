using System.Collections.Generic;
using backend.Models;

namespace backend.Dtos
{
    public class PointItemsReadDto
    {        
        public int Id { get; set; }        
        public string Image { get; set; }      
        public string Image_url { 
            get {
                return $"http://192.168.2.101/Uploads/{Image}";
            }
        }    
        public string Name { get; set; }        
        public string Email { get; set; }        
        public string Whatsapp { get; set; }        
        public decimal Latitude { get; set; }        
        public decimal Longitude { get; set; }        
        public string City { get; set; }                
        public string Uf { get; set; }  
        public IEnumerable<ItemInPointReadDto> Items { get; set; } 
    }    
}