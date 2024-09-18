using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.Interface
{
    public interface IProjectServices
    {
        Task<List<Project>> GetAll();
        Task<Project> InsertProject(Project project);
        Task<InformationProjectResponse> CreateProject(CreateProjectRequest request);
        Task<InformationProjectResponse> GetById(Guid id);
        Task<List<ProjectResponse>> GetAllFiltered(string? name, int CampaignTypeId, int ClientId, int pageNumber, int pageSize);
        Task<TaskResponse> AddTask(CreateTaskRequest task, Guid id);
        Task<InteractionsResponse> AddInteraction(CreateInteractionRequest interaction, Guid id);
        Task<TaskResponse> UpdateTask(CreateTaskRequest createTaskRequest, Guid id);
    }
}
