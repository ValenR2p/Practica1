using Application.Interface;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TaskStatusQuery : ITaskStatusQuery
    {
        private readonly ApiContext _apiContext;
        public TaskStatusQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<Domain.Entities.TaskStatus> GetById(int id)
        {
            var taskStatus = await _apiContext.TaskStatus.FindAsync(id);
            return taskStatus;
        }
        public async Task<List<Domain.Entities.TaskStatus>> ListGetAll()
        {
            return await _apiContext.TaskStatus.ToListAsync();
        }
    }
}
