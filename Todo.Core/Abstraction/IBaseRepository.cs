namespace Todo.Core.Abstraction;

public interface IBaseRepository<T> where T : BaseEntity
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task CommitChangesAsync();
    void CommitChanges();
}
