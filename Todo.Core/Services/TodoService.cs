namespace Todo.Core.Services;


using Todo.Core.Abstraction;
using Todo.Core.Entities;

public class TodoService: BaseService<Todo>, ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository) : base(todoRepository)
    {
        _todoRepository = todoRepository;
    }
}
