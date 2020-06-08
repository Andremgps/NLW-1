using System.Collections.Generic;
using AutoMapper;
using backend.Data.Abstract;
using backend.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _repository;
        private readonly IMapper _mapper;

        public ItemsController(IItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetAllItems(){
            var items = _repository.GetAllItems();
            var itemsReadDto = _mapper.Map<IEnumerable<ItemReadDto>>(items);
            return Ok(itemsReadDto);
        }
    }
}