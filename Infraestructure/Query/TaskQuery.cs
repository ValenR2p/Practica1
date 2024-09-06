using Application.Interface;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TaskQuery : ITaskQuery
    {
        private readonly ApiContext _apiContext;
        public TaskQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<List<Domain.Entities.Task>> ListGetAllById(Guid id)
        {
            var tasks = await _apiContext.Tasks.
                Include(s => s.User).
                Include(s => s.TaskStatus).
                Where(s => s.ProjectID == id).ToListAsync();
            return tasks;   
        }
        public async Task<Domain.Entities.Task> ListGetById(Guid id)
        {
            var tasks = await _apiContext.Tasks.
                Include(s => s.User).
                Include(s => s.TaskStatus).
                FirstOrDefaultAsync(s => s.TaskID == id);
            return tasks;
        }
    }
}
