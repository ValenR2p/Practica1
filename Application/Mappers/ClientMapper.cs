using Application.IMapper;
using Application.Interface;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public Task<List<ClientResponse>> GetClients(List<Client> clients)
        {
            List<ClientResponse> responses = new List<ClientResponse>();
            foreach (var client in clients)
            {
                var response = new ClientResponse
                {
                    ClientID = client.ClientID,
                    Name = client.Name,
                    Email = client.Email,
                    Phone = client.Phone,
                    Company = client.Company,
                    Address = client.Address,
                };
                responses.Add(response);
            }
            return System.Threading.Tasks.Task.FromResult(responses);
        }

        public Task<ClientResponse> GetOneClient(Client client)
        {
            var response = new ClientResponse
            {
                ClientID = client.ClientID,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Company = client.Company,
                Address = client.Address,
            };
            return System.Threading.Tasks.Task.FromResult(response);
        }
    }
}
