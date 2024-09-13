using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IInteractionMapper
    {
        Task<List<InteractionsResponse>> GetInteractions(List<Interaction> interactions);
    }
}
