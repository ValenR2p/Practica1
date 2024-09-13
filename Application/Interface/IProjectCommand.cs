using Domain.Entities;

namespace Application.Interface
{
    public interface IProjectCommand
    {
        public System.Threading.Tasks.Task InsertProject(Project project);
        public System.Threading.Tasks.Task UpdateProject(Project project);
    }
}
