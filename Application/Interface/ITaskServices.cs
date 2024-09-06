using Application.Models;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITaskServices
    {
        Task<Domain.Entities.Task> InsertTask(Domain.Entities.Task task);
        Task<TaskResponse> CreateTask(CreateTaskRequest request, Guid id);
        Task<List<TaskResponse>> GetAllTasksById(Guid id);
        Task<TaskResponse> UpdateTask(CreateTaskRequest request, Guid id);
    }
}
