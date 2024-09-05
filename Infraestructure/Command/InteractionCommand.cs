using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class InteractionCommand : IInteractionCommand
    {
        private readonly ApiContext _apiContext;
        public InteractionCommand(ApiContext context)
        {
            _apiContext = context;
        }
        public async System.Threading.Tasks.Task InsertInteraction(Interaction interaction)
        {
            _apiContext.Add(interaction);
            await _apiContext.SaveChangesAsync();
        }
    }
}
