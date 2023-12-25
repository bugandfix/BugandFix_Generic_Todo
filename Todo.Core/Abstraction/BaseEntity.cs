using System;

namespace Todo.Core.Abstraction;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
}
