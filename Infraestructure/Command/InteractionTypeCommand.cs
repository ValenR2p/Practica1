using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class InteractionTypeCommand : IInteractionTypeCommand
    {
        private readonly ApiContext _apiContext;
        public InteractionTypeCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertInteractionType(InteractionType interactionType)
        {
            _apiContext.Add(interactionType);
            await _apiContext.SaveChangesAsync();
        }
    }
}
