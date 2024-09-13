using Application.Interface;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponse>), 200)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _services.GetAll();
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
    }
}
