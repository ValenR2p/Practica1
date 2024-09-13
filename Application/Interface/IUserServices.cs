using Application.Response;

namespace Application.Interface
{
    public interface IUserServices
    {
        Task<UserResponse> GetById(int id);
        Task<List<UserResponse>> GetAll();
    }
}
