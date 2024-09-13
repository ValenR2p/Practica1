using Domain.Entities;

namespace Application.Interface
{
    public interface IClientCommand
    {
        public System.Threading.Tasks.Task InsertClient(Client client);
    }
}
