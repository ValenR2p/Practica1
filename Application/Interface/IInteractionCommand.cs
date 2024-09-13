using Domain.Entities;

namespace Application.Interface
{
    public interface IInteractionCommand
    {
        public System.Threading.Tasks.Task InsertInteraction(Interaction interaction);
    }
}
