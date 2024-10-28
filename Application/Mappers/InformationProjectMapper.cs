using Application.IMapper;
using Application.Interface;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class InformationProjectMapper : IInformationProjectMapper
    {
        private readonly IProjectMapper _projectMapper;
        private readonly IInteractionServices _interactionServices;
        private readonly ITaskServices _taskServices;

        public InformationProjectMapper(IProjectMapper projectMapper, IInteractionServices interactionServices,
            ITaskServices taskServices)
        {
            _projectMapper = projectMapper;
            _interactionServices = interactionServices;
            _taskServices = taskServices;
        }
        public async Task<InformationProjectResponse> GetProject(Project project)
        {
            var response = new InformationProjectResponse
            {
                Data = await _projectMapper.GetOneProject(project),
                Tasks = await _taskServices.GetAllTasksById(project.ProjectID),
                Interactions = await _interactionServices.GetAllInteractionsById(project.ProjectID)
            };
            return await System.Threading.Tasks.Task.FromResult(response);
        }
    }
}
