using Application.Exceptions;
using Application.IMapper;
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


        public async Task<ClientResponse> CreateClient(ClientRequest request)
        {
            var client = new Client
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Company = request.Company,
                Address = request.Address,
                CreateDate = DateTime.Now
            };
            if (string.IsNullOrEmpty(client.Name))
            {
                throw new BadRequestException("Name value can not be empty");
            }
            else if (string.IsNullOrEmpty(client.Email))
            {
                throw new BadRequestException("Email value can not be empty");
            }
            else if (string.IsNullOrEmpty(client.Phone))
            {
                throw new BadRequestException("Phone value can not be empty");
            }
            else if (string.IsNullOrEmpty(client.Company))
            {
                throw new BadRequestException("Company value can not be empty");
            }
            else if (string.IsNullOrEmpty(client.Address))
            {
                throw new BadRequestException("Adress value can not be empty");
            }
            else if (!client.Email.Contains("@") && !client.Email.Contains(".com")) 
            {
                throw new BadRequestException("The email must have a @ and .com");
            }
            else if (client.Phone.Any(char.IsLetter))
            {
                throw new BadRequestException("The phone can only have numbers");
            }
            else if (client.Phone.Count() <= 8)
            {
                throw new BadRequestException("The phone must contain at least 8 numbers");
            }
            await _command.InsertClient(client);
            return await _mapper.GetOneClient(client);
        }


        public async Task<ClientResponse> GetById(int id)
        {
            var client = await _query.ListGetById(id);
            return await _mapper.GetOneClient(client);
        }
    }
}
