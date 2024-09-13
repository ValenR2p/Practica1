using Application.IMapper;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class GenericMapper : IGenericMapper
    {
        public Task<List<GenericResponse>> GetCampaignType(List<CampaignType> campaignsTypes)
        {
            List<GenericResponse> responses = new List<GenericResponse>();
            foreach (var campaignType in campaignsTypes)
            {
                var response = new GenericResponse
                {
                    Id = campaignType.Id,
                    Name = campaignType.Name,
                };
                responses.Add(response);
            }
            return System.Threading.Tasks.Task.FromResult(responses);
        }
        public Task<GenericResponse> GetOneCampaignType(CampaignType campaignType)
        {
            var response = new GenericResponse
            {
                Id = campaignType.Id,
                Name = campaignType.Name,
            };
            return System.Threading.Tasks.Task.FromResult(response);
        }

        public Task<List<GenericResponse>> GetInteractionType(List<InteractionType> interactionTypes)
        {
            List<GenericResponse> responses = new List<GenericResponse>();
            foreach (var interactionType in interactionTypes)
            {
                var response = new GenericResponse
                {
                    Id = interactionType.Id,
                    Name = interactionType.Name,
                };
                responses.Add(response);
            }
            return System.Threading.Tasks.Task.FromResult(responses);
        }
        public Task<GenericResponse> GetOneInteractionType(InteractionType interactionType)
        {
            var response = new GenericResponse
            {
                Id = interactionType.Id,
                Name = interactionType.Name,
            };
            return System.Threading.Tasks.Task.FromResult(response);
        }

        public Task<GenericResponse> GetOneTaskStatus(Domain.Entities.TaskStatus taskStatus)
        {
            var response = new GenericResponse
            {
                Id = taskStatus.Id,
                Name = taskStatus.Name,
            };
            return System.Threading.Tasks.Task.FromResult(response);
        }

        public Task<List<GenericResponse>> GetTaskStatus(List<Domain.Entities.TaskStatus> tasksStatus)
        {
            List<GenericResponse> responses = new List<GenericResponse>();
            foreach (var taskStatus in tasksStatus)
            {
                var response = new GenericResponse
                {
                    Id = taskStatus.Id,
                    Name = taskStatus.Name,
                };
                responses.Add(response);
            }
            return System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
