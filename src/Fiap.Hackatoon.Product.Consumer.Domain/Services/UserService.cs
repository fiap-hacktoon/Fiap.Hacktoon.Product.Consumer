using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Services;

public class UserService(IUserRepository userRepository) : BaseService<User>(userRepository), IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> GetById(Guid id)
    {
        return await _userRepository.GetById(id, false, false);
    }

    public override async Task<User> Add(User entity)
    {
        var user = await _userRepository.GetByEmail(entity.Email);

        if (user != null)
            throw new Exception("O usuário já existe.");

        entity.PrepareToInsert();
        
        return await base.Add(entity);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRepository.GetByEmail(email);
    }
}