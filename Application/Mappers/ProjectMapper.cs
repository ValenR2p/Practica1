using Application.IMapper;
using Application.Interface;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly IClientMapper _clientMapper;
        private readonly IGenericMapper _campaignMapper;
        private readonly IClientServices _clientServices;
        private readonly ICampaignTypeServices _campaignTypeServices;
        public ProjectMapper(IClientMapper clientMapper, IGenericMapper campaignMapper, ICampaignTypeServices campaignTypeServices, IClientServices clientServices)
        {
            _clientMapper = clientMapper;
            _campaignMapper = campaignMapper;
            _campaignTypeServices = campaignTypeServices;
            _clientServices = clientServices;
        }

        public async Task<ProjectResponse> GetOneProject(Project project)
        {
            var response = new ProjectResponse
            {
                //Puede ser que el Client y el Campaign traidos del objeto de nombre project sean null, a pesar del include
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                //Client = await _clientMapper.GetOneClient(project.Client),
                Client = await _clientServices.GetById(project.ClientID),
                //Campaign = await _campaignMapper.GetOneCampaignType(project.Campaign),
                Campaign = await _campaignTypeServices.GetById(project.CampaignType),
            };
            return await System.Threading.Tasks.Task.FromResult(response);
        }

        public async Task<List<ProjectResponse>> GetProjects(List<Project> projects)
        {
            List<ProjectResponse> responses = new List<ProjectResponse>();
            foreach (var project in projects)
            {
                var response = new ProjectResponse
                {
                    ProjectID = project.ProjectID,
                    ProjectName = project.ProjectName,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Client = await _clientMapper.GetOneClient(project.Client),
                    Campaign = await _campaignMapper.GetOneCampaignType(project.Campaign),

                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
