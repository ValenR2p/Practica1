﻿using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class ClientServices : IClientServices
    {

        private readonly IClientQuery _query;
        private readonly IClientCommand _command;
        private readonly IClientMapper _mapper;
        public ClientServices(IClientQuery query, IClientCommand command, IClientMapper mapper)
        {
            _query = query;
            _command = command;
            _mapper = mapper;
        }
        public async Task<List<ClientResponse>> GetAll()
        {
            var clients = await _query.ListGetAll();
            return await _mapper.GetClients(clients);
        }

        public async Task<Client> InsertClient(Client client)
        {
            await _command.InsertClient(client);
            return client;
        }
        public async Task<ClientResponse> CreateClient(CreateClientRequest request)
        {
            var client = new Client
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Company = request.Company,
                Address = request.Address,
            };
            await _command.InsertClient(client);
            return await this.GetById(client.ClientID);
        }

        public async Task<ClientResponse> GetById(int id)
        {
            var client = await _query.ListGetById(id);
            return await _mapper.GetOneClient(client);
        }
    }
}