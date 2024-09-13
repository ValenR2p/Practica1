using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IUserMapper
    {
        Task<List<UserResponse>> GetUsers(List<User> users);
        Task<UserResponse> GetOneUser(User user);
    }
}
