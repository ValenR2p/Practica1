using Application.Models;
using Application.Response;

namespace Application.Interface
{
    public interface ITaskServices
    {
        Task InsertTask(Domain.Entities.Task task);
        Task<TaskResponse> CreateTask(TaskRequest request, Guid id);
        Task<List<TaskResponse>> GetAllTasksById(Guid id);
        Task<TaskResponse> UpdateTask(TaskRequest request, Guid id);
    }
}
