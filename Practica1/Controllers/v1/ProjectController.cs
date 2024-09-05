using Application.Interface;
using Application.Models;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _services;
        public ProjectController(IProjectServices services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProjectResponse>), 200)]
        //Ver lo de la paginacion
        public async Task<IActionResult> GetAllFiltered(int campaignTypeId, string? projectName,
            int clientId, int pageNumber = 1, int pageSize = 1)
        {
            var result = await _services.GetAllFiltered(projectName, campaignTypeId, clientId);
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<InformationProjectResponse>), 200)]
        //Añadir lo de que salte un error si se crea un Project cuyo nombre ya esta usado
        public async Task<IActionResult> CreateProject(CreateProjectRequest request)
        {
            var result = await _services.CreateProject(request);
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<InformationProjectResponse>), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _services.GetById(id);
            //Cambiar, por un "return ok;"
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        [HttpPost("{id}/interactions")]
        [ProducesResponseType(typeof(List<InteractionsResponse>), 200)]
        public async Task<IActionResult> AddInteraction(CreateInteractionRequest createInteractionRequest, Guid id)
        {
            var newInteraction = await _services.AddInteraction(createInteractionRequest, id);
            return new JsonResult(newInteraction)
            {
                StatusCode = 200
            };
        }
        [HttpPost("{id}/tasks")]
        [ProducesResponseType(typeof(List<TaskResponse>), 200)]
        public async Task<IActionResult> AddTask(CreateTaskRequest createTaskRequest, Guid id)
        {
            var newTask = await _services.AddTask(createTaskRequest, id);
            return new JsonResult(newTask)
            {
                StatusCode = 200
            };
        }
        [HttpPut("/api/Tasks/{id}")]
        public async Task<IActionResult> UpdateTask(Guid id)
        {
            var project = await _services.GetById(id);
            return new JsonResult(project);
        }
    }
}
