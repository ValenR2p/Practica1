﻿using Application.Interface;
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
        public async Task<List<Project>> ListGetByFilter(string? name, int? CampaignTypeId, int? ClientId, int? offset, int? size)
        {
            var projects = _apiContext.Projects.
                Include(s => s.Campaign).
                Include(s => s.Client).
                OrderBy(p => p.ProjectName).
                AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                projects = projects.Where(p => p.ProjectName.Contains(name));
            }
            if (CampaignTypeId.HasValue)
            {
                projects = projects.Where(p => p.CampaignType == CampaignTypeId.Value);
            }
            if (ClientId.HasValue)
            {
                projects = projects.Where(p => p.ClientID == ClientId.Value);
            }
            if (offset.HasValue)
            {
                projects = projects.Skip(offset.Value);
            }
            if (size.HasValue)
            {
                projects = projects.Take(size.Value);
            }
            return await projects.ToListAsync();
        }
        public async Task<Project> GetByName(string name) {
            var project = _apiContext.Projects.
                Include(s => s.Campaign).
                Include(s => s.Client).
                FirstOrDefault(s => s.ProjectName == name);
            return project;
        }

    }
}
