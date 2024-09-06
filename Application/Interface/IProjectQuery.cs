using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProjectQuery
    {
        Task<List<Project>> ListGetAll();
        Task<Project> ListGetById(Guid id);
        Task<List<Project>> ListGetByFilter(string? name, int? CampaignTypeId, int? ClientId);
    }
}
