using Domain.Entities;

namespace Application.Interface
{
    public interface IInteractionQuery
    {
        Task<List<Interaction>> ListGetAllById(Guid id);
    }
}
