using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class CampaignTypeCommand : ICampaignTypeCommand
    {

        //Injecta el contexto
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
