using Domain.Entities;

namespace Application.Interface
{
    public interface IInteractionTypeQuery
    {
        Task<List<InteractionType>> ListGetAll();
        Task<InteractionType> GetById(int id);
    }
}
