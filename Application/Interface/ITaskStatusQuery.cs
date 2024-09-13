namespace Application.Interface
{
    public interface ITaskStatusQuery
    {
        Task<List<Domain.Entities.TaskStatus>> ListGetAll();
        Task<Domain.Entities.TaskStatus> GetById(int id);
    }
}
