using Application.Exceptions;
using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectQuery _query;
        private readonly IProjectCommand _command;
        private readonly IProjectMapper _mapper;
        private readonly ITaskServices _taskServices; 
        private readonly IInteractionServices _interactionServices;
        private readonly IInformationProjectMapper _informationProjectMapper;
        public ProjectServices(IProjectQuery query, IProjectCommand command, 
            IClientServices clientServices, ICampaignTypeServices campaignTypeServices,
            ITaskServices taskServices, IUserServices userServices, 
            ITaskStatusServices taskStatusServices, IProjectMapper mapper, 
            IInformationProjectMapper informationProjectMapper, IInteractionServices interactionServices)
        {
            _query = query;
            _command = command;
            _taskServices = taskServices;
            _mapper = mapper;
            _informationProjectMapper = informationProjectMapper;
            _interactionServices = interactionServices;
        }
        public async Task<List<Project>> GetAll()
        {
            return await _query.ListGetAll();
        }
        public async Task<Project> InsertProject(Project project)
        {
            await _command.InsertProject(project);
            return project;
        }
        public async Task<InformationProjectResponse> CreateProject(CreateProjectRequest request)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ClientID = request.ClientID,
                CampaignType = request.CampaignType,
            };
            var projectSearch = await _query.ListGetByFilter(project.ProjectName, null, null);
            if (projectSearch != null)
            {
                throw new ObjectAlreadyExistsException("The Project with the Name " + project.ProjectName + " already exists, please use another name");
            }
            else
            {
                await _command.InsertProject(project);
                return new InformationProjectResponse
                {
                    data = await _mapper.GetOneProject(project),
                    tasks = await _taskServices.GetAllTasksById(project.ProjectID),
                    interactions = await _interactionServices.GetAllInteractionsById(project.ProjectID)
                };
            }
        }
        public async Task<InformationProjectResponse> GetById(Guid id)
        {
            if (_query.ListGetById(id) != null)
            {
                var project = await _query.ListGetById(id);
                return await _informationProjectMapper.GetProject(project);
            }
            else {
                throw new ObjectNotFoundException("The Project with ID: " + id + " does not exist");
            }
        }
        public async Task<List<ProjectResponse>> GetAllFiltered(string? name, int CampaignTypeId, int ClientId)
        {
            var projects = await _query.ListGetByFilter( name,  CampaignTypeId,  ClientId);
            return await _mapper.GetProjects(projects);
        }
        public async Task<TaskResponse> AddTask(CreateTaskRequest request, Guid id)
        {
            if (_query.ListGetById(id) != null)
            {
                var NewTask = await _taskServices.CreateTask(request, id);
                return NewTask;
            }
            else {
                throw new ObjectNotFoundException("The Project with ID: " + id + " does not exist"); 
            }
        }
        public async Task<InteractionsResponse> AddInteraction(CreateInteractionRequest request, Guid id)
        {
            if (_query.ListGetById(id) != null)
            {
                var NewInteraction = await _interactionServices.CreateInteraction(request, id);
                return NewInteraction;
            }
            else
            {
                throw new ObjectNotFoundException("The Project with ID: " + id + " does not exist");
            }
        }
        public async Task<TaskResponse> UpdateTask(CreateTaskRequest createTaskRequest, Guid id)
        {
            var updatedTask = await _taskServices.UpdateTask(createTaskRequest, id);
            return updatedTask;
        }
    }
}
