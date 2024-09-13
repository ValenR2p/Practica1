using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly ApiContext _apiContext;
        public ProjectCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertProject(Project project)
        {
            _apiContext.Add(project);
            await _apiContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateProject(Project project)
        {
            _apiContext.Projects.Update(project);
            await _apiContext.SaveChangesAsync();
        }
    }
}
