using Application.Response;

namespace Application.Interface
{
    public interface IInteractionTypeServices
    {
        Task<List<GenericResponse>> GetAll();
        Task<GenericResponse> GetById(int id);
    }
}
