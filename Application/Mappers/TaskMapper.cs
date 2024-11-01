﻿using Application.IMapper;
using Application.Response;

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
                Id = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectId = task.ProjectID,
                Status = await _taskStatusMapper.GetOneTaskStatus(task.TaskStatus),
                UserAssigned = await _userMapper.GetOneUser(task.User)
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
                    Id = task.TaskID,
                    Name = task.Name,
                    DueDate = task.DueDate,
                    ProjectId = task.ProjectID,
                    Status = await _taskStatusMapper.GetOneTaskStatus(task.TaskStatus),
                    UserAssigned = await _userMapper.GetOneUser(task.User)
                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
