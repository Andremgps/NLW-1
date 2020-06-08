using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.Profiles
{
    public class PointsItemsProfile : Profile
    {
        public PointsItemsProfile()
        {
            CreateMap<PointItemCreateDto, Point_Item>();
        }
    }
}