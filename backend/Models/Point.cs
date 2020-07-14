using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
  public class Point
  {
    [Key]
    public int Id { get; set; }
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

    public ICollection<Point_Item> Point_Item { get; set; }
  }
}