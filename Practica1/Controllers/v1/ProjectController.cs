using Application.Exceptions;
using Application.Interface;
using Application.Models;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> GetAllFiltered(string? name, int? campaign,
            int? client, int? offset, int? size)
        {
            try
            {
                var result = await _services.GetAllFiltered(name, campaign, client, offset, size);
                return new JsonResult(result)
                {
                    StatusCode = 200
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { Message = ex.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error has ocurred", details = ex.Message });
            }

        }


        [HttpPost]
        [ProducesResponseType(typeof(InformationProjectResponse), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> CreateProject(ProjectRequest request)
        {
            try
            {      
                var result = await _services.CreateProject(request);
                return new JsonResult(result)
                {
                    StatusCode = 201
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { Message = ex.message });
            }
            catch(Exception ex){
                return StatusCode(500,new { message = "An unexpected error has ocurred", details = ex.Message});
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InformationProjectResponse), 200)]
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
                return NotFound(new ExceptionResponse { Message = ex.message });
            }
        }


        [HttpPatch("{id}/interactions")]
        [ProducesResponseType(typeof(InteractionsResponse), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> AddInteraction(InteractionRequest createInteractionRequest, Guid id)
        {
            try
            {
                var newInteraction = await _services.AddInteraction(createInteractionRequest, id);
                return new JsonResult(newInteraction)
                {
                    StatusCode = 201
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { Message = ex.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error has ocurred", details = ex.Message });
            }
        }


        [HttpPatch("{id}/tasks")]
        [ProducesResponseType(typeof(TaskResponse), 201)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> AddTask(TaskRequest createTaskRequest, Guid id)
        {
            try
            {
                var newTask = await _services.AddTask(createTaskRequest, id);
                return new JsonResult(newTask)
                {
                    StatusCode = 201
                };
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ExceptionResponse { Message = ex.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error has ocurred", details = ex.Message });
            }
        }


        [HttpPut("/api/v1/Tasks/{id}")]
        [ProducesResponseType(typeof(TaskResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        public async Task<IActionResult> UpdateTask(TaskRequest createTaskRequest, Guid id)
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
                return BadRequest(new ExceptionResponse { Message = ex.message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error has ocurred", details = ex.Message });
            }
        }
    }
}
