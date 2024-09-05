using Application.IMapper;
using Application.Interface;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class UserServices : IUserServices
    {
        private readonly IUserQuery _query;
        private readonly IUserMapper _mapper;
        public UserServices(IUserQuery query, IUserMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<UserResponse> GetById(int id)
        {
            var user = await _query.GetById(id);
            return await _mapper.GetOneUser(user);
        }
        public async Task<List<UserResponse>> GetAll()
        {
            var users = await _query.ListGetAll();
            return await _mapper.GetUsers(users);
        }
    }
}
