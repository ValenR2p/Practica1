using Application.Response;

namespace Application.Interface
{
    public interface ITaskStatusServices
    {
        Task<List<GenericResponse>> GetAll();
        Task<GenericResponse> GetById(int id);
    }
}
