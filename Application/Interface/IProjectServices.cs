using Application.Models;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProjectServices
    {
        Task<List<Project>> GetAll();
        Task<Project> InsertProject(Project project);
        Task<InformationProjectResponse> CreateProject(CreateProjectRequest request);
        Task<InformationProjectResponse> GetById(Guid id);
        Task<List<ProjectResponse>> GetAllFiltered(string? name, int CampaignTypeId, int ClientId);
        Task<TaskResponse> AddTask(CreateTaskRequest task, Guid id);
        Task<InteractionsResponse> AddInteraction(CreateInteractionRequest interaction, Guid id);
        Task<Project> UpdateTask(Domain.Entities.Task task, Guid id);
    }
}
