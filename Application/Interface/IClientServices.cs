using Application.Models;
using Application.Response;

namespace Application.Interface
{
    public interface IClientServices
    {
        Task<List<ClientResponse>> GetAll();
        Task<ClientResponse> CreateClient(CreateClientRequest request);
        Task<ClientResponse> GetById(int id);
    }
}
