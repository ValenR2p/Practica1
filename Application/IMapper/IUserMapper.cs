using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMapper
{
    public interface IUserMapper
    {
        Task<List<UserResponse>> GetUsers(List<User> users);
        Task<UserResponse> GetOneUser(User user);
    }
}
