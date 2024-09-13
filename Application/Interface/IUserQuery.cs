using Domain.Entities;

namespace Application.Interface
{
    public interface IUserQuery
    {
        Task<User> GetById(int id);
        Task<List<User>> ListGetAll();
    }
}
