using Application.Exceptions;
using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;

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


        public async Task<TaskResponse> CreateTask(CreateTaskRequest request, Guid id)
        {
            var task = new Domain.Entities.Task
            {
                Name = request.Name,
                DueDate = request.DueDate,
                AssignedTo = request.AssignedTo,
                Status = request.Status,
                ProjectID = id,
            };
            var taskStatusSearch = await _taskStatusQuery.GetById(task.Status);
            var userSearch = await _userQuery.GetById(task.AssignedTo);
            if (task.Name == "string" || task.Name == "" || task.Status <= 0 || task.AssignedTo <= 0)
            {
                throw new BadRequestException("The Request contains a non acceptable value");
            }
            else if (taskStatusSearch == null || userSearch == null)
            {
                throw new BadRequestException("There is no Task or User with the chosen ID´s");
            }
            await _command.InsertTask(task);
            return await _mapper.GetOneTask(task);
        }


        public async Task<List<TaskResponse>> GetAllTasksById(Guid id)
        {
            var tasks = await _query.ListGetAllById(id);
            return await _mapper.GetTasks(tasks);
        }


        public async Task InsertTask(Domain.Entities.Task task)
        {
            await _command.InsertTask(task);
        }
        public async Task<TaskResponse> UpdateTask(CreateTaskRequest request, Guid id)
        {
            var task = await _query.ListGetById(id);
            if (task != null)
            {
                task.Name = request.Name;
                task.DueDate = request.DueDate;
                task.AssignedTo = request.AssignedTo;
                task.Status = request.Status;
                task.UpdateDate = DateTime.Now;
            }
            else
            {
                throw new BadRequestException("Task with the ID " + id + " not Found");
            }
            var taskStatusSearch = await _taskStatusQuery.GetById(task.Status);
            var userSearch = await _userQuery.GetById(task.AssignedTo);
            if (task.Name == "string" || task.Name == "" || task.Status <= 0 || task.AssignedTo <= 0)
            {
                throw new BadRequestException("The Request contains a non acceptable value");
            }
            else if (taskStatusSearch == null || userSearch == null)
            {
                throw new BadRequestException("There is no Task or User with the chosen ID´s");
            }
            await _command.UpdateTask(task);
            return await _mapper.GetOneTask(task);
        }
    }
}
