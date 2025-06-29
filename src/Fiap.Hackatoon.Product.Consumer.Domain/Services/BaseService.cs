using Fiap.Hackatoon.Product.Consumer.Domain.Entities.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;
using System.Linq.Expressions;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Services
{
    public abstract class BaseService<T>(
        IRepository<T> repository) : IBaseService<T> where T : class, IBaseEntity
    {
        protected readonly IRepository<T> _repository = repository;

        public virtual async Task<T> Add(T entity)
        {
            entity.PrepareToInsert();
            return await _repository.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task Remove(T entity)
        {
            entity.PrepareToRemove();
            await _repository.Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<T> Update(T entity)
        {
            entity.PrepareToUpdate();
            return await _repository.Update(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            _repository.Dispose();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return _repository.FindBy(expression);
        }
    }
}