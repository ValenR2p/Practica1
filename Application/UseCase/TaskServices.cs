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
        private readonly ITaskStatusServices _taskStatusServices;
        private readonly IUserServices _userServices;

        public TaskServices(ITaskCommand command, ITaskQuery query, ITaskMapper mapper,
            IUserServices userServices, ITaskStatusServices taskStatusServices)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _taskStatusServices = taskStatusServices;
            _userServices = userServices;
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
            await _command.InsertTask(task);
            return new TaskResponse
            {
                TaskID = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectID = task.ProjectID,
                TaskStatus = await _taskStatusServices.GetById(request.Status),
                User = await _userServices.GetById(request.AssignedTo), 
            };
        }
        public async Task<List<TaskResponse>> GetAllTasksById(Guid id)
        {
            var tasks = await _query.ListGetAllById(id);
            return await _mapper.GetTasks(tasks);
        }
        public async Task<Domain.Entities.Task> InsertTask(Domain.Entities.Task task)
        {
            await _command.InsertTask(task);
            throw new NotImplementedException();
        }
    }
}
