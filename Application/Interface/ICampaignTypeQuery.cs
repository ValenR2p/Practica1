using Domain.Entities;

namespace Application.Interface
{
    public interface ICampaignTypeQuery
    {
        Task<List<CampaignType>> ListGetAll();
        Task<CampaignType> GetCampaignTypes(int id);
    }
}
