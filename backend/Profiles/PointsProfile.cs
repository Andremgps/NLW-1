using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.Profiles
{
    public class PointsProfile : Profile
    {
        public PointsProfile()
        {
            CreateMap<Point, PointReadDto>();
            CreateMap<Point, PointItemsReadDto>();
            CreateMap<PointCreateDto, Point>();
        }
    }
}