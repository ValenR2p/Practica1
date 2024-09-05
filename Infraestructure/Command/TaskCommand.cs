using Application.Interface;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class TaskCommand : ITaskCommand
    {
        private readonly ApiContext _apiContext;
        public TaskCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertTask(Domain.Entities.Task task)
        {
            _apiContext.Add(task);
            await _apiContext.SaveChangesAsync();
        }
    }
}
