using Application.IMapper;
using Application.Interface;
using Application.Response;

namespace Application.UseCase
{
    public class TaskStatusServices : ITaskStatusServices
    {
        private readonly ITaskStatusQuery _query;
        private readonly IGenericMapper _mapper;
        public TaskStatusServices(ITaskStatusQuery query, IGenericMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<List<GenericResponse>> GetAll()
        {
            var tasksStatus = await _query.ListGetAll();
            return await _mapper.GetTaskStatus(tasksStatus);
        }
        public async Task<GenericResponse> GetById(int id)
        {
            var taskStatus = await _query.GetById(id);
            return await _mapper.GetOneTaskStatus(taskStatus);
        }
    }
}
