using Domain.Entities;

namespace Application.Interface
{
    public interface IInteractionTypeCommand
    {
        public System.Threading.Tasks.Task InsertInteractionType(InteractionType campaignType);
    }
}