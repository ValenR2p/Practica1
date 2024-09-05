using Application.IMapper;
using Application.Interface;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class TaskMapper : ITaskMapper
    {
        private readonly IGenericMapper _taskStatusMapper;
        private readonly IUserMapper _userMapper;

        public TaskMapper(IUserMapper userMapper, IGenericMapper taskStatusMapper)
        {
            _taskStatusMapper = taskStatusMapper;
            _userMapper = userMapper;
        }

        public async Task<TaskResponse> GetOneTask(Domain.Entities.Task task)
        {
            var response = new TaskResponse
            {
                TaskID = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectID = task.ProjectID,
                //TaskStatus = task.TaskStatus,
                TaskStatus = await _taskStatusMapper.GetOneTaskStatus(task.TaskStatus),
                //User = task.User,
                User = await _userMapper.GetOneUser(task.User)
            };
            return await System.Threading.Tasks.Task.FromResult(response);
        }

        public async Task<List<TaskResponse>> GetTasks(List<Domain.Entities.Task> tasks)
        {
            List<TaskResponse> responses = new List<TaskResponse>();
            foreach (var task in tasks)
            {
                var response = new TaskResponse
                {
                    TaskID = task.TaskID,
                    Name = task.Name,
                    DueDate = task.DueDate,
                    ProjectID = task.ProjectID,
                    //TaskStatus = task.TaskStatus,
                    TaskStatus = await _taskStatusMapper.GetOneTaskStatus(task.TaskStatus),
                    //User = task.User,
                    User = await _userMapper.GetOneUser(task.User)
                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
