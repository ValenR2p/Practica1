using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IGenericMapper
    {
        Task<List<GenericResponse>> GetCampaignType(List<CampaignType> campaignsTypes);
        Task<GenericResponse> GetOneCampaignType(CampaignType campaignType);
        Task<List<GenericResponse>> GetInteractionType(List<InteractionType> interactionTypes);
        Task<GenericResponse> GetOneInteractionType(InteractionType interactionType);
        Task<List<GenericResponse>> GetTaskStatus(List<Domain.Entities.TaskStatus> taskStatuses);
        Task<GenericResponse> GetOneTaskStatus(Domain.Entities.TaskStatus taskStatus);
    }
}
