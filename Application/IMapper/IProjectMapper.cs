using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IProjectMapper
    {
        Task<List<ProjectResponse>> GetProjects(List<Project> projects);
        Task<ProjectResponse> GetOneProject(Project project);
    }
}
