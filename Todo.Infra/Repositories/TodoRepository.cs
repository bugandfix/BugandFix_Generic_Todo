namespace Todo.Infra.Repositories;

using Todo.Core.Abstraction;
using Todo.Core.DataContext;
using Todo.Core.Entities;


public class TodoRepository: BaseRepository<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDataContext context): base(context)
    {
    }

    
}
