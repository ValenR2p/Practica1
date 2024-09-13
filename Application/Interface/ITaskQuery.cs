namespace Application.Interface
{
    public interface ITaskQuery
    {
        Task<List<Domain.Entities.Task>> ListGetAllById(Guid id);
        Task<Domain.Entities.Task> ListGetById(Guid id);
    }
}
