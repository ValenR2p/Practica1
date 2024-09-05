using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMapper
{
    public interface ITaskMapper
    {
        Task<List<TaskResponse>> GetTasks(List<Domain.Entities.Task> tasks);
        Task<TaskResponse> GetOneTask(Domain.Entities.Task task);
    }
}
