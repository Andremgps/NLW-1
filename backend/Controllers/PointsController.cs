using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using backend.Data.Abstract;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("points")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointRepo _pointRepositoy;
        private readonly IItemRepo _itemRepositoy;
        private readonly IMapper _mapper;

        public PointsController(IPointRepo pointRepositoy, IItemRepo itemRepositoy, IMapper mapper)
        {
            _pointRepositoy = pointRepositoy;
            _itemRepositoy = itemRepositoy;
            _mapper = mapper;

        }

        [HttpGet("{id}", Name="GetPointById")]
        public ActionResult<PointReadDto> GetPointById(int id)
        {
            var point = _pointRepositoy.GetPointById(id);
            if(point == null){
                return NotFound();
            }
            var pointReadDto = _mapper.Map<PointReadDto>(point);
            return Ok(pointReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointReadDto>> GetFilteredPoints([FromQuery]string city, [FromQuery]string uf, [FromQuery]string items)
        {
            if(city == null || uf == null || items == null){
                return BadRequest();
            }
            List<int> parsedItems = items.Split(',').Select(item => int.Parse(item)).ToList();
            var points = _pointRepositoy.GetFilteredPoints(city, uf, parsedItems); 
            var pointReadDto = _mapper.Map<IEnumerable<PointReadDto>>(points);
            return Ok(pointReadDto);
        }

        [HttpGet("pointItems/{id}")]
        public ActionResult<PointItemsReadDto> GetPointItemsByPointId(int id)
        {
            var point = _pointRepositoy.GetPointById(id);
            if(point == null){
                return NotFound();
            }
            var pointItemsReadDto = _mapper.Map<PointItemsReadDto>(point);
            var pointItems = _itemRepositoy.GetItemsByPointId(id);
            var itemInPointReadDto = _mapper.Map<IEnumerable<ItemInPointReadDto>>(pointItems);
            pointItemsReadDto.Items = itemInPointReadDto;
            return Ok(pointItemsReadDto);
        }

        [HttpPost]
        public ActionResult<PointReadDto> CreatePoint(PointCreateDto pointCreateDto)
        {     
            var transaction = _pointRepositoy.BeginTransaction();
            try
            {
                var pointModel = _mapper.Map<Point>(pointCreateDto);
                _pointRepositoy.CreatePoint(pointModel);
                _pointRepositoy.SaveChanges();
                var pointReadDto = _mapper.Map<PointReadDto>(pointModel);

                List<PointItemCreateDto> pointItems = new List<PointItemCreateDto>();
                foreach(int itemId in pointCreateDto.Items)
                {
                    pointItems.Add(new PointItemCreateDto {
                        Item_Id = itemId, 
                        Point_Id = pointReadDto.Id
                    });
                }
                var pointItemsModelList = _mapper.Map<List<Point_Item>>(pointItems);
                _pointRepositoy.CreatePointItems(pointItemsModelList);
                _pointRepositoy.SaveChanges();  
                transaction.Commit();  
                                        
                return CreatedAtRoute(
                    nameof(GetPointById),
                    new { Id = pointReadDto.Id },
                    pointReadDto
                );      
            }
            catch(Exception)
            {
                transaction.Rollback();
                return BadRequest();
            }
                              
        }
    }
}