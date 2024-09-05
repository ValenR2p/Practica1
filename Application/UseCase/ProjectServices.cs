﻿using Application.IMapper;
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
            await _command.InsertProject(project);
            return new InformationProjectResponse {
                
                data = await _mapper.GetOneProject(project),
                tasks = await _taskServices.GetAllTasksById(project.ProjectID),
                interactions = await _interactionServices.GetAllInteractionsById(project.ProjectID)
            };
        }
        public async Task<InformationProjectResponse> GetById(Guid id)
        {
            var project = await _query.ListGetById(id);
            return await _informationProjectMapper.GetProject(project);
        }
        public async Task<List<ProjectResponse>> GetAllFiltered(string? name, int CampaignTypeId, int ClientId)
        {
            var projects = await _query.ListGetByFilter( name,  CampaignTypeId,  ClientId);
            return await _mapper.GetProjects(projects);
        }
        public async Task<TaskResponse> AddTask(CreateTaskRequest request, Guid id)
        {
            var NewTask = await _taskServices.CreateTask(request, id);
            return NewTask;
        }
        public async Task<InteractionsResponse> AddInteraction(CreateInteractionRequest request, Guid id)
        {
            var NewInteraction = await _interactionServices.CreateInteraction(request, id);
            return NewInteraction;
        }
        public async Task<Project> UpdateTask(Domain.Entities.Task task, Guid id)
        {
            var project = await _query.ListGetById(id);
            throw new NotImplementedException();
        }
    }
}