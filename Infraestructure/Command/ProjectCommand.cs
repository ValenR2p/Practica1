using Domain.Entities;
using Application.Interface;
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
    }
}
