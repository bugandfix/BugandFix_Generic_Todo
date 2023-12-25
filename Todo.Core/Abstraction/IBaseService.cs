using Ardalis.Result;

namespace Todo.Core.Abstraction;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Result<TEntity> GetById(int id);
    Result<IEnumerable<TEntity>> GetAll();
    Task<Result<TEntity>> Add(TEntity entity);
    Task<Result<TEntity>> Update(TEntity entity);
    Task<Result<bool>> Delete(int id);
}
