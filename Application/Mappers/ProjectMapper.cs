using Application.IMapper;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly IClientMapper _clientMapper;
        private readonly IGenericMapper _campaignMapper;

        public ProjectMapper(IClientMapper clientMapper, IGenericMapper campaignMapper)
        {
            _clientMapper = clientMapper;
            _campaignMapper = campaignMapper;
        }

        public async Task<ProjectResponse> GetOneProject(Project project)
        {
            var response = new ProjectResponse
            {
                Id = project.ProjectID,
                Name = project.ProjectName,
                Start = project.StartDate,
                End = project.EndDate,
                Client = await _clientMapper.GetOneClient(project.Client),
                CampaignType = await _campaignMapper.GetOneCampaignType(project.Campaign),
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
                    Id = project.ProjectID,
                    Name = project.ProjectName,
                    Start = project.StartDate,
                    End = project.EndDate,
                    Client = await _clientMapper.GetOneClient(project.Client),
                    CampaignType = await _campaignMapper.GetOneCampaignType(project.Campaign),
                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
