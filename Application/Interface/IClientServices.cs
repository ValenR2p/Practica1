using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.Interface
{
    public interface IClientServices
    {
        Task<List<ClientResponse>> GetAll();
        Task<Client> InsertClient(Client client);
        Task<ClientResponse> CreateClient(CreateClientRequest request);
        Task<ClientResponse> GetById(int id);
    }
}
