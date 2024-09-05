using Application.Interface;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusServices _services;
        public TaskStatusController(ITaskStatusServices services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
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

