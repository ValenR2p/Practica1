using Application.Models;
using Application.Response;

namespace Application.Interface
{
    public interface IInteractionServices
    {
        Task InsertInteraction(Domain.Entities.Interaction interaction);
        Task<InteractionsResponse> CreateInteraction(InteractionRequest request, Guid id);
        Task<List<InteractionsResponse>> GetAllInteractionsById(Guid id);
    }
}
