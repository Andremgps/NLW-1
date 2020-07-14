using AutoMapper;
using backend.Dtos;
using backend.Models;
using System.Globalization;

namespace backend.Profiles
{
  public class PointsProfile : Profile
  {
    public PointsProfile()
    {
      CreateMap<Point, PointReadDto>();
      CreateMap<Point, PointItemsReadDto>();
      CreateMap<PointCreateDto, Point>()
        .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => decimal.Parse(src.Latitude, CultureInfo.InvariantCulture)))
        .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => decimal.Parse(src.Longitude, CultureInfo.InvariantCulture)));
    }
  }
}