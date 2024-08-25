using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly ApiContext _apiContext;

        public CampaignTypeQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public List<CampaignType> ListGetAll()
        {
            return _apiContext.CampaignTypes.ToList();
            
            //throw new NotImplementedException();
        }
    }
}
