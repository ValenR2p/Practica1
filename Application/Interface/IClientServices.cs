using Application.Models;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
