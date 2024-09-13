using Domain.Entities;

namespace Application.Interface
{
    public interface IClientQuery
    {
        Task<List<Client>> ListGetAll();
        Task<Client> ListGetById(int id);
    }
}
