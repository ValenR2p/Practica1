using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly ApiContext _apiContext;
        public ProjectQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<List<Project>> ListGetAll()
        {
            return await _apiContext.Projects.ToListAsync();
        }
        public async Task<Project> ListGetById(Guid id)
        {
            var project = _apiContext.Projects.
                Include(s => s.Campaign).
                Include(s => s.Client).
                FirstOrDefault(s => s.ProjectID == id);
            return project;
        }
        public async Task<List<Project>> ListGetByFilter(string? name, int? CampaignTypeId, int? ClientId)
        {
            if (name != null || CampaignTypeId != 0 || ClientId != 0)
            {
                var projects = await _apiContext.Projects.
                    Include(s => s.Client).
                    Include(s => s.Campaign).
                    Where(p => (string.IsNullOrEmpty(name) || p.ProjectName == name) && (p.CampaignType == CampaignTypeId ||
                    CampaignTypeId == 0) && (p.ClientID == ClientId || ClientId == 0)).ToListAsync();
                return projects;
            }
            return new List<Project>();
        }
    }
}
