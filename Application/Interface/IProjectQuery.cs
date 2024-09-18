using Domain.Entities;

namespace Application.Interface
{
    public interface IProjectQuery
    {
        Task<List<Project>> ListGetAll();
        Task<Project> ListGetById(Guid id);
        Task<List<Project>> ListGetByFilter(string? name, int? CampaignTypeId, int? ClientId, int pageNumber, int pageSize);
    }
}
