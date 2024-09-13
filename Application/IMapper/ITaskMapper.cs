using Application.Response;

namespace Application.IMapper
{
    public interface ITaskMapper
    {
        Task<List<TaskResponse>> GetTasks(List<Domain.Entities.Task> tasks);
        Task<TaskResponse> GetOneTask(Domain.Entities.Task task);
    }
}
