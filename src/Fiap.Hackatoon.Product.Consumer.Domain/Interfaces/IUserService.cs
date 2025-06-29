using Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;

public interface IUserService : IBaseService<User>
{
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
}