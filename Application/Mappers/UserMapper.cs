using Application.IMapper;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public Task<UserResponse> GetOneUser(User user)
        {
            var response = new UserResponse
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
            };
            return System.Threading.Tasks.Task.FromResult(response);
        }

        public Task<List<UserResponse>> GetUsers(List<User> users)
        {
            List<UserResponse> responses = new List<UserResponse>();
            foreach (var user in users)
            {
                var response = new UserResponse
                {
                    UserID = user.UserID,
                    Name = user.Name,
                    Email = user.Email,
                };
                responses.Add(response);
            }
            return System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
