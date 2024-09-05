using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMapper
{
    public interface IProjectMapper
    {
        Task<List<ProjectResponse>> GetProjects(List<Project> projects);
        Task<ProjectResponse> GetOneProject(Project project);
    }
}
