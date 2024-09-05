using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class CampaignTypeCommand : ICampaignTypeCommand
    {

        private readonly ApiContext _apiContext;
        public CampaignTypeCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertCampaignType(CampaignType campaignType)
        {
            _apiContext.Add(campaignType);
            await _apiContext.SaveChangesAsync();
        }

    }
}
