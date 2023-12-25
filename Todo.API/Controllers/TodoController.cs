

namespace Todo.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Abstraction;
using Todo.Core.Entities;
using Todo.Core.DTOs.TodoDtos;

[Route("api/[controller]")]
[ApiController]
public class TodoController : GenericController<Todo,TodoDto, TodoReadDto, TodoDto>
{
    public TodoController(ITodoService todoService, IMapper mapper): base(todoService, mapper)
    {
    }
}
