using Todo.Core.Abstraction;

namespace Todo.Core.Entities;

public partial class Todo: BaseEntity 
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
