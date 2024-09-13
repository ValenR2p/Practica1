using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IClientMapper
    {
        Task<List<ClientResponse>> GetClients(List<Client> clients);
        Task<ClientResponse> GetOneClient(Client client);
    }
}
