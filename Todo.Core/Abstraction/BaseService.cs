using System;
using System.Collections.Generic;
using Ardalis.Result;
using System.Threading.Tasks;

namespace Todo.Core.Abstraction
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> repository) => _repository = repository;

        public async Task<Result<TEntity>> Add(TEntity entity)
        {
            Result<TEntity> result;
            try
            {
                _repository.Add(entity);
                await _repository.CommitChangesAsync();
                result = Result<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
                result = Result<TEntity>.Error(ex.Message);
                return result;
            }
            return result;
        }

        public async Task<Result<bool>> Delete(int id)
        {
            Result<bool> result;
            try
            {
                var entityTracking = _repository.GetById(id);
                if (entityTracking == null)
                {
                    result = Result<bool>.NotFound();
                    return result;
                }
                _repository.Delete(entityTracking);
                await _repository.CommitChangesAsync();
                result = Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                result = Result<bool>.Error(ex.Message);
                return result;
            }
            return result;
        }

        public Result<IEnumerable<TEntity>> GetAll()
        {
            Result<IEnumerable<TEntity>> result;
            IEnumerable<TEntity> entities;
            try
            {
                entities = _repository.GetAll();

                if (entities == null)
                    entities = Array.Empty<TEntity>();

                result = Result<IEnumerable<TEntity>>.Success(entities);
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<TEntity>>.Error(ex.Message);
                return result;
            }
            return result;
        }

        public Result<TEntity> GetById(int id)
        {
            Result<TEntity> result;
            TEntity entity;
            try
            {
                entity = _repository.GetById(id);
                result = Result<TEntity>.Success(entity);
            }
            catch (Exception ex)
            {
                result = Result<TEntity>.Error(ex.Message);
                return result;
            }
            return result;
        }

        public async Task<Result<TEntity>> Update(TEntity entity)
        {
            Result<TEntity> result;
            try
            {
                var entityTracking = _repository.GetById(entity.Id);
                if (entityTracking == null)
                {
                    result = Result<TEntity>.NotFound();
                    return result;
                }
                _repository.Update(entityTracking);
                await _repository.CommitChangesAsync();
                result = Result<TEntity>.Success(entityTracking);
            }
            catch (Exception ex)
            {
                result = Result<TEntity>.Error(ex.Message);
                return result;
            }
            return result;
        }
    }
}
