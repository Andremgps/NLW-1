using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AutoMapper;
using backend.Data.Abstract;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
  [Route("points")]
  [ApiController]
  public class PointsController : ControllerBase
  {
    private readonly IPointRepo _pointRepositoy;
    private readonly IItemRepo _itemRepositoy;
    private readonly IMapper _mapper;

    private IWebHostEnvironment _hostingEnvironment;

    public PointsController(IPointRepo pointRepositoy, IItemRepo itemRepositoy, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
      _pointRepositoy = pointRepositoy;
      _itemRepositoy = itemRepositoy;
      _mapper = mapper;
      _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet("{id}", Name = "GetPointById")]
    public ActionResult<PointReadDto> GetPointById(int id)
    {
      var point = _pointRepositoy.GetPointById(id);
      if (point == null)
      {
        return NotFound();
      }
      var pointReadDto = _mapper.Map<PointReadDto>(point);
      return Ok(pointReadDto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PointReadDto>> GetFilteredPoints([FromQuery] string city, [FromQuery] string uf, [FromQuery] string items)
    {
      if (city == null || uf == null)
      {
        return BadRequest();
      }
      List<int> parsedItems = items != null ? items.Split(',').Select(item => int.Parse(item)).ToList() : new List<int>();
      var points = _pointRepositoy.GetFilteredPoints(city, uf, parsedItems);
      var pointReadDto = _mapper.Map<IEnumerable<PointReadDto>>(points);
      return Ok(pointReadDto);
    }

    //Listagem de pontos com seus items
    [HttpGet("pointWithItems/{id}")]
    public ActionResult<PointItemsReadDto> GetPointItemsByPointId(int id)
    {
      var point = _pointRepositoy.GetPointById(id);
      if (point == null)
      {
        return NotFound();
      }
      var pointItemsReadDto = _mapper.Map<PointItemsReadDto>(point);
      var pointItems = _itemRepositoy.GetItemsByPointId(id);
      var itemInPointReadDto = _mapper.Map<IEnumerable<ItemInPointReadDto>>(pointItems);
      pointItemsReadDto.Items = itemInPointReadDto;
      return Ok(pointItemsReadDto);
    }

    private string UploadImage(IFormFile image)
    {
      string extension = Path.GetExtension(image.FileName);
      string fileName = image.FileName.Split(".")[0] + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;
      string path = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads/" + fileName);
      using (var stream = new FileStream(path, FileMode.Create))
      {
        image.CopyTo(stream);
      }
      return fileName;
    }

    [HttpPost]
    public ActionResult<PointReadDto> CreatePoint([FromForm] PointCreateDto pointCreateDto, [FromForm(Name = "imageContent")] IFormFile image)
    {
      var transaction = _pointRepositoy.BeginTransaction();
      try
      {

        Console.Write(pointCreateDto.Latitude);

        pointCreateDto.Image = UploadImage(image);

        var pointModel = _mapper.Map<Point>(pointCreateDto);
        _pointRepositoy.CreatePoint(pointModel);
        _pointRepositoy.SaveChanges();
        var pointReadDto = _mapper.Map<PointReadDto>(pointModel);

        List<PointItemCreateDto> pointItems = new List<PointItemCreateDto>();
        foreach (int itemId in pointCreateDto.Items.Split(",").Select(item => int.Parse(item)).ToList())
        {
          pointItems.Add(new PointItemCreateDto
          {
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
      catch (Exception)
      {
        transaction.Rollback();
        return BadRequest();
      }

    }
  }
}