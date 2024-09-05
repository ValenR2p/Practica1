using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly ApiContext _apiContext;
        public UserQuery(ApiContext context)
        {
            _apiContext = context;
        }

        public async Task<List<User>> ListGetAll()
        {
            return await _apiContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _apiContext.Users.FindAsync(id);
            return user;
        }
    }
}
