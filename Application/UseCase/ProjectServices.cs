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
        private readonly IClientQuery _clientQuery;
        private readonly ITaskServices _taskServices;
        private readonly ICampaignTypeQuery _campaignTypeQuery;
        private readonly IInteractionServices _interactionServices;
        private readonly IInformationProjectMapper _informationProjectMapper;
        public ProjectServices(IProjectQuery query, IProjectCommand command,
            IClientQuery clientQuery, ITaskServices taskServices,
            IProjectMapper mapper, IInformationProjectMapper informationProjectMapper,
            IInteractionServices interactionServices, ICampaignTypeQuery campaignTypeQuery)
        {
            _query = query;
            _command = command;
            _taskServices = taskServices;
            _mapper = mapper;
            _informationProjectMapper = informationProjectMapper;
            _interactionServices = interactionServices;
            _clientQuery = clientQuery;
            _campaignTypeQuery = campaignTypeQuery;
        }


        public async Task<List<Project>> GetAll()
        {
            return await _query.ListGetAll();
        }


        public async Task<InformationProjectResponse> CreateProject(CreateProjectRequest request)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                ClientID = request.ClientID,
                CampaignType = request.CampaignType,
                StartDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                EndDate = request.EndDate,
            };
            var projectSearch = await _query.ListGetByFilter(project.ProjectName, null, null, null, null);
            var clientSearch = await _clientQuery.ListGetById(project.ClientID);
            var campaignTypeSearch = await _campaignTypeQuery.GetCampaignTypes(project.CampaignType);
            if (projectSearch.Count != 0)
            {
                throw new BadRequestException("The Project with the Name " + project.ProjectName + " already exists, please use another name");
            }
            else if (project.ProjectName == "string" || project.ProjectName == "" || project.ClientID == 0 || project.CampaignType == 0)
            {
                throw new BadRequestException("The Request contains a non acceptable value");
            }
            else if (clientSearch == null || campaignTypeSearch == null)
            {
                throw new BadRequestException("There is no Client or Campaign Type with the chosen ID´s");
            }
            await _command.InsertProject(project);
            return new InformationProjectResponse
            {
                data = await _mapper.GetOneProject(project),
                tasks = await _taskServices.GetAllTasksById(project.ProjectID),
                interactions = await _interactionServices.GetAllInteractionsById(project.ProjectID)
            };
        }


        public async Task<InformationProjectResponse> GetById(Guid id)
        {
            var test = await _query.ListGetById(id);
            if (test != null)
            {
                return await _informationProjectMapper.GetProject(test);
            }
            else
            {
                throw new ObjectNotFoundException("The Project with ID: " + id + " does not exist");
            }
        }


        public async Task<List<ProjectResponse>> GetAllFiltered(string? name, int? CampaignTypeId, int? ClientId, int? pageNumber, int? pageSize)
        {
            var projects = await _query.ListGetByFilter(name, CampaignTypeId, ClientId, pageNumber, pageSize);
            return await _mapper.GetProjects(projects);
        }


        public async Task<TaskResponse> AddTask(CreateTaskRequest request, Guid id)
        {
            var projectToUpdate = await _query.ListGetById(id);
            if (projectToUpdate != null)
            {
                var newTask = await _taskServices.CreateTask(request, id);
                projectToUpdate.UpdateDate = DateTime.Now;
                await _command.UpdateProject(projectToUpdate);
                return newTask;
            }
            else
            {
                throw new BadRequestException("The Project with ID: " + id + " does not exist");
            }
        }


        public async Task<InteractionsResponse> AddInteraction(CreateInteractionRequest request, Guid id)
        {
            var projectToUpdate = await _query.ListGetById(id);
            if (projectToUpdate != null)
            {
                var newInteraction = await _interactionServices.CreateInteraction(request, id);
                projectToUpdate.UpdateDate = DateTime.Now;
                await _command.UpdateProject(projectToUpdate);
                return newInteraction;
            }
            else
            {
                throw new ObjectNotFoundException("The Project with ID: " + id + " does not exist");
            }
        }


        public async Task<TaskResponse> UpdateTask(CreateTaskRequest createTaskRequest, Guid id)
        {
            var updatedTask = await _taskServices.UpdateTask(createTaskRequest, id);
            var projectToUpdate = await _query.ListGetById(updatedTask.ProjectID);
            projectToUpdate.UpdateDate = DateTime.Now;
            await _command.UpdateProject(projectToUpdate);
            return updatedTask;
        }
    }
}
