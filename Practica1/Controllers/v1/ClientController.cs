using Application.Interface;
using Application.Models;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _services;
        public ClientController(IClientServices services)
        {
            _services = services;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<ClientResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<ClientResponse>), 200)]
        public async Task<IActionResult> CreateClient(CreateClientRequest request)
        {
            var result = await _services.CreateClient(request);
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }

    }
}
