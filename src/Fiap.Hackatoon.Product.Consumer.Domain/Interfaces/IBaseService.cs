using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;

public interface IBaseService<T> : IRepository<T> where T : class, IBaseEntity
{
    Task Remove(T entity);
}