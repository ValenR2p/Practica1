using Application.Exceptions;
using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;

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


        public async Task<InformationProjectResponse> CreateProject(ProjectRequest request)
        {
            var project = new Project
            {
                ProjectName = request.Name,
                ClientID = request.Client,
                CampaignType = request.CampaignType,
                StartDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                EndDate = request.End,
            };

            if (await _query.GetByName(request.Name) != null) {
                throw new BadRequestException("The Project with the Name " + project.ProjectName + " already exists, please use another name");
            }
            else if (string.IsNullOrEmpty(project.ProjectName))
            {
                throw new BadRequestException("The Notes must contain something");
            }
            else if (project.CampaignType <= 0)
            {
                throw new BadRequestException("Campaign Type can not be lower than 1");
            }
            else if (project.ClientID <= 0 )
            {
                throw new BadRequestException("Client ID can not be lower than 1");
            }
            else if (await _clientQuery.ListGetById(project.ClientID) == null) 
            {
                throw new BadRequestException("There is no Client with the chosen ID");
            }
            else if (await _campaignTypeQuery.GetCampaignTypes(project.CampaignType) == null)
            {
                throw new BadRequestException("There is no Campaign Type with the chosen ID");
            }
            else if (project.EndDate <= project.StartDate)
            {
                throw new BadRequestException("The project End Date can not be earlier than the Start or Creation Date");
            }
            await _command.InsertProject(project);
            return new InformationProjectResponse
            {
                Data = await _mapper.GetOneProject(project),
                Tasks = await _taskServices.GetAllTasksById(project.ProjectID),
                Interactions = await _interactionServices.GetAllInteractionsById(project.ProjectID)
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


        public async Task<List<ProjectResponse>> GetAllFiltered(string? name, int? CampaignTypeId, int? ClientId, int? offset, int? size)
        {
            if (offset < 0) {
                throw new BadRequestException("The offset value can not be negative");
            }
            if (size < 0)
            {
                throw new BadRequestException("The size value can not be negative");
            }
            var projects = await _query.ListGetByFilter(name, CampaignTypeId, ClientId, offset, size);
            return await _mapper.GetProjects(projects);
        }


        public async Task<TaskResponse> AddTask(TaskRequest request, Guid id)
        {
            var projectToUpdate = await _query.ListGetById(id);
            if (projectToUpdate != null)
            {
                if (projectToUpdate.CreateDate < request.DueDate) {
                    throw new BadRequestException("The Due Date for the desired task can not be before the projects Creation Date");
                }
                else if (projectToUpdate.StartDate < request.DueDate)
                {
                    throw new BadRequestException("The Due Date for the desired task can not be before the projects Start Date");
                }
                else if (DateTime.Now < request.DueDate)
                {
                    throw new BadRequestException("The Date for the desired interaction is set to an already passed date");
                }
                else if (projectToUpdate.EndDate < request.DueDate)
                {
                    throw new BadRequestException("The Due Date for the desired task can not be after the projects End Date");
                }
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


        public async Task<InteractionsResponse> AddInteraction(InteractionRequest request, Guid id)
        {
            var projectToUpdate = await _query.ListGetById(id);
            if (projectToUpdate != null)
            {
                if (projectToUpdate.CreateDate < request.Date)
                {
                    throw new BadRequestException("The Date for the desired interaction can not be before the projects Creation Date");
                }
                else if (projectToUpdate.StartDate < request.Date)
                {
                    throw new BadRequestException("The Date for the desired interaction can not be before the projects Start Date");
                }
                else if (DateTime.Now < request.Date)
                {
                    throw new BadRequestException("The Date for the desired interaction is set to an already passed date");
                }
                else if (projectToUpdate.EndDate < request.Date)
                {
                    throw new BadRequestException("The Date for the desired interaction can not be after the projects End Date");
                }
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


        public async Task<TaskResponse> UpdateTask(TaskRequest createTaskRequest, Guid id)
        {   
            var updatedTask = await _taskServices.UpdateTask(createTaskRequest, id);
            var projectToUpdate = await _query.ListGetById(updatedTask.ProjectId);
            projectToUpdate.UpdateDate = DateTime.Now;
            await _command.UpdateProject(projectToUpdate);
            return updatedTask;
        }
    }
}
