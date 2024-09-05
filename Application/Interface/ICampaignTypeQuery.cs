using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICampaignTypeQuery
    {
        Task<List<CampaignType>> ListGetAll();
        Task<CampaignType> GetCampaignTypes(int id);
    }
}
