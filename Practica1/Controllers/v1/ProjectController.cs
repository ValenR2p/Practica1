using Application.Exceptions;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;
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
        public async Task<IActionResult> GetAllFiltered(int campaignTypeId, string? projectName,
            int clientId, int pageNumber, int pageSize)
        {
            var result = await _services.GetAllFiltered(projectName, campaignTypeId, clientId);
            //var paginatedResult = result
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToList();
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<InformationProjectResponse>), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> CreateProject(CreateProjectRequest request)
        {
            try
            {
                var result = await _services.CreateProject(request);
                return new JsonResult(result)
                {
                    StatusCode = 200
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { message = ex.message });
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<InformationProjectResponse>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _services.GetById(id);
                return new JsonResult(result)
                {
                    StatusCode = 200
                };
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(new ExceptionResponse { message = ex.message });
            }
        }
        [HttpPost("{id}/interactions")]
        [ProducesResponseType(typeof(List<InteractionsResponse>), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> AddInteraction(CreateInteractionRequest createInteractionRequest, Guid id)
        {
            try
            {
                var newInteraction = await _services.AddInteraction(createInteractionRequest, id);
                return new JsonResult(newInteraction)
                {
                    StatusCode = 200
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { message = ex.message });
            }
        }
        [HttpPost("{id}/tasks")]
        [ProducesResponseType(typeof(List<TaskResponse>), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> AddTask(CreateTaskRequest createTaskRequest, Guid id)
        {
            try
            {
                var newTask = await _services.AddTask(createTaskRequest, id);
                return new JsonResult(newTask)
                {
                    StatusCode = 200
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { message = ex.message });
            }
        }
        [HttpPut("/api/v1/Tasks/{id}")]
        [ProducesResponseType(typeof(List<TaskResponse>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> UpdateTask(CreateTaskRequest createTaskRequest, Guid id)
        {
            try
            {
                var updatedTask = await _services.UpdateTask(createTaskRequest, id);
                return new JsonResult(updatedTask)
                {
                    StatusCode = 200
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { message = ex.message });
            }
        }
    }
}
