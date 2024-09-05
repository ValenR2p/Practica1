using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly ApiContext _apiContext;
        public CampaignTypeQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<CampaignType> GetCampaignTypes(int id)
        {
            return await _apiContext.CampaignTypes.FindAsync(id);
        }
        public async Task<List<CampaignType>> ListGetAll()
        {
            return await _apiContext.CampaignTypes.ToListAsync();
        }
    }
}
