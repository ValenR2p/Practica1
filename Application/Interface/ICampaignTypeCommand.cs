using Domain.Entities;

namespace Application.Interface
{
    public interface ICampaignTypeCommand
    {
        public System.Threading.Tasks.Task InsertCampaignType(CampaignType campaignType);
    }
}