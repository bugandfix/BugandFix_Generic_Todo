
namespace Todo.API.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Todo.Core.Abstraction;
using Ardalis.Result;
using Todo.Core.Responses;

[Route("api/[controller]")]
[ApiController]
public abstract class GenericController<TEntity, TCreateDto, TReadDto, TUpdateDto> : ControllerBase 
    where TEntity : BaseEntity 
    where TCreateDto : class 
    where TReadDto : class
    where TUpdateDto : class
{
    private readonly IBaseService<TEntity> _service;
    private readonly IMapper _mapper;


    public GenericController(IBaseService<TEntity> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        ApiResponse<IEnumerable<TReadDto>> response;
        var result = _service.GetAll();
        if (result.Status == ResultStatus.Error)
        {
            var emptyResult = Array.Empty<TReadDto>();
            response = new ApiResponse<IEnumerable<TReadDto>>(emptyResult, HttpStatusCode.InternalServerError)
            {
                Message = "Somthing is wrong",
                Errors = result.Errors,
                Title = nameof(HttpStatusCode.InternalServerError)
            };
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
        var entitiesReadDto = _mapper.Map<IEnumerable<TReadDto>>(result.Value);
        response = new ApiResponse<IEnumerable<TReadDto>>(entitiesReadDto, HttpStatusCode.OK)
        {
            Title = nameof(HttpStatusCode.OK)
        };
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        ApiResponse<TReadDto> response;
        var result = _service.GetById(id);
        if(result.Status == ResultStatus.Error)
        {
            response = new ApiResponse<TReadDto>(null, HttpStatusCode.InternalServerError)
            {
                Message = "Somthing is wrong",
                Errors = result.Errors,
                Title = nameof(HttpStatusCode.InternalServerError)
            };
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        var entityReadDto = _mapper.Map<TReadDto>(result.Value);
        response = new ApiResponse<TReadDto>(entityReadDto, HttpStatusCode.OK)
        {
            Title = nameof(HttpStatusCode.OK)
        };
        return Ok(response);
    }


}
