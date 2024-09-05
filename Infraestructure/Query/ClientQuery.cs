using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class ClientQuery : IClientQuery
    {
        private readonly ApiContext _apiContext;
        public ClientQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<Client> ListGetById(int id)
        {
            return _apiContext.Clients.FirstOrDefault(s => s.ClientID == id);
        }
        public async Task<List<Client>> ListGetAll()
        {
            return await _apiContext.Clients.ToListAsync();
        }
    }
}
