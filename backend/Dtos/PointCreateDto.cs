using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System;

namespace backend.Dtos
{
  public class PointCreateDto
  {

    public FormFile ImageContent { get; set; }
    public string Image { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Whatsapp { get; set; }
    [Required]
    public string Latitude { get; set; }
    [Required]
    public string Longitude { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    [MaxLength(2)]
    public string Uf { get; set; }
    public string Items { get; set; }
  }
}