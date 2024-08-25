using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CampaignTypeServices : ICampaignTypeServices
    {
        private readonly ICampaignTypeQuery _query;
        private readonly ICampaignTypeCommand _command;

        public CampaignTypeServices(ICampaignTypeQuery query, ICampaignTypeCommand command)
        {
            _query = query;
            _command = command;
        }
        public async Task<List<CampaignType>> GetAll()
        {
            var campaignTypes = new List<CampaignType>
            {
                new CampaignType { Name = "SEO" },
                new CampaignType { Name = "PPC" },
                new CampaignType { Name = "Social Media" },
                new CampaignType { Name = "Email Marketin" }
            };
            foreach (var campaignType in campaignTypes) {
                await _command.InsertCampaignType(campaignType);
            }

            return _query.ListGetAll();
            //return campaignTypes;
            //throw new NotImplementedException();
        }
    }
}
