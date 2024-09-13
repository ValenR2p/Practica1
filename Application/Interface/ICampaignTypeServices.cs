using Application.Response;

namespace Application.Interface
{
    public interface ICampaignTypeServices
    {
        Task<List<GenericResponse>> GetAll();
        Task<GenericResponse> GetById(int id);
    }
}
