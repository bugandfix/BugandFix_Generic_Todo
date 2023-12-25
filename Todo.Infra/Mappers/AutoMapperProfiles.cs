

namespace Todo.Infra.Mappers;

using AutoMapper;
using Todo.Core.Entities;
using Todo.Core.DTOs.TodoDtos;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Todo, TodoReadDto>();
        CreateMap<TodoReadDto, Todo>();
        CreateMap<TodoDto, Todo>();
        CreateMap<Todo, TodoDto>();
    }
}
