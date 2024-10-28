using Application.Exceptions;
using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskCommand _command;
        private readonly ITaskQuery _query;
        private readonly ITaskMapper _mapper;
        private readonly ITaskStatusQuery _taskStatusQuery;
        private readonly IUserQuery _userQuery;

        public TaskServices(ITaskCommand command, ITaskQuery query, ITaskMapper mapper,
        ITaskStatusQuery taskStatusQuery, IUserQuery userQuery)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _taskStatusQuery = taskStatusQuery;
            _userQuery = userQuery;
        }


        public async Task<TaskResponse> CreateTask(TaskRequest request, Guid id)
        {
            var task = new Domain.Entities.Task
            {
                Name = request.Name,
                DueDate = request.DueDate,
                AssignedTo = request.User,
                Status = request.Status,
                ProjectID = id,
                CreateDate = DateTime.Now
            };
            var taskStatusSearch = await _taskStatusQuery.GetById(task.Status);
            var userSearch = await _userQuery.GetById(task.AssignedTo);
            if (string.IsNullOrEmpty(task.Name))
            {
                throw new BadRequestException("The Notes must contain something");
            }
            else if (taskStatusSearch == null)
            {
                throw new BadRequestException("There is no Task with the chosen ID´s");
            }
            else if (userSearch == null)
            {
                throw new BadRequestException("There is no User with the chosen ID");
            }
            else if (task.AssignedTo <= 0)
            {
                throw new BadRequestException("The User assiged number can not be lower than 1");
            }
            else if (task.Status <= 0)
            {
                throw new BadRequestException("The Status number can not be lower than 1");
            }
            else if (task.DueDate <= task.CreateDate)
            {
                throw new BadRequestException("The project End Date can not be earlier than the Start or Creation Date");
            }
            await _command.InsertTask(task);
            return await _mapper.GetOneTask(task);
        }


        public async Task<List<TaskResponse>> GetAllTasksById(Guid id)
        {
            var tasks = await _query.ListGetAllById(id);
            return await _mapper.GetTasks(tasks);
        }


        public async System.Threading.Tasks.Task InsertTask(Domain.Entities.Task task)
        {
            await _command.InsertTask(task);
        }
        public async Task<TaskResponse> UpdateTask(TaskRequest request, Guid id)
        {
            var task = await _query.ListGetById(id);
            if (task != null)
            {
                task.Name = request.Name;
                task.DueDate = request.DueDate;
                task.AssignedTo = request.User;
                task.Status = request.Status;
                task.UpdateDate = DateTime.Now;
            }
            else
            {
                throw new BadRequestException("Task with the ID " + id + " not Found");
            }
            var taskStatusSearch = await _taskStatusQuery.GetById(task.Status);
            var userSearch = await _userQuery.GetById(task.AssignedTo);
            if (string.IsNullOrEmpty(task.Name))
            {
                throw new BadRequestException("The Notes must contain something");
            }
            else if (taskStatusSearch == null)
            {
                throw new BadRequestException("There is no Task with the chosen ID´s");
            }
            else if (userSearch == null)
            {
                throw new BadRequestException("There is no User with the chosen ID");
            }
            else if (task.AssignedTo <= 0)
            {
                throw new BadRequestException("The User assiged number can not be lower than 1");
            }
            else if (task.Status <= 0)
            {
                throw new BadRequestException("The Status number can not be lower than 1");
            }
            else if (task.DueDate <= task.CreateDate)
            {
                throw new BadRequestException("The project End Date can not be earlier than the Start or Creation Date");
            }
            await _command.UpdateTask(task);
            return await _mapper.GetOneTask(task);
        }
    }
}
