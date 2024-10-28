using Application.Models;
using Application.Response;
using Domain.Entities;
using System.Drawing;

namespace Application.Interface
{
    public interface IProjectServices
    {
        Task<List<Project>> GetAll();
        Task<InformationProjectResponse> CreateProject(ProjectRequest request);
        Task<InformationProjectResponse> GetById(Guid id);
        Task<List<ProjectResponse>> GetAllFiltered(string? name, int? CampaignTypeId, int? ClientId, int? offset, int? size);
        Task<TaskResponse> AddTask(TaskRequest task, Guid id);
        Task<InteractionsResponse> AddInteraction(InteractionRequest interaction, Guid id);
        Task<TaskResponse> UpdateTask(TaskRequest request, Guid id);
    }
}
