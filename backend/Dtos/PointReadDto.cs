namespace backend.Dtos
{
    public class PointReadDto
    {        
        public int Id { get; set; }        
        public string Image { get; set; }        
        public string Name { get; set; }        
        public string Email { get; set; }        
        public string Whatsapp { get; set; }        
        public decimal Latitude { get; set; }        
        public decimal Longitude { get; set; }        
        public string City { get; set; }                
        public string Uf { get; set; }   
    }    
}