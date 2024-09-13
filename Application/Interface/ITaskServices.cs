using Application.Models;
using Application.Response;

namespace Application.Interface
{
    public interface ITaskServices
    {
        Task<Domain.Entities.Task> InsertTask(Domain.Entities.Task task);
        Task<TaskResponse> CreateTask(CreateTaskRequest request, Guid id);
        Task<List<TaskResponse>> GetAllTasksById(Guid id);
        Task<TaskResponse> UpdateTask(CreateTaskRequest request, Guid id);
    }
}
