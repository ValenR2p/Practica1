using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly ApiContext _apiContext;
        public ClientCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertClient(Client client)
        {
            _apiContext.Add(client);
            await _apiContext.SaveChangesAsync();
        }
    }
}
