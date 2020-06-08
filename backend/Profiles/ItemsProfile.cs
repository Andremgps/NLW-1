using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.Profiles
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<Item, ItemInPointReadDto>();
        }
    }
}