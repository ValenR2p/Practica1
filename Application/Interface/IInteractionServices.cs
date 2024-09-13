using Application.Models;
using Application.Response;

namespace Application.Interface
{
    public interface IInteractionServices
    {
        Task<Domain.Entities.Interaction> InsertInteraction(Domain.Entities.Interaction interaction);
        Task<InteractionsResponse> CreateInteraction(CreateInteractionRequest request, Guid id);
        Task<List<InteractionsResponse>> GetAllInteractionsById(Guid id);
    }
}
