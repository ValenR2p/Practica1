using Application.IMapper;
using Application.Interface;
using Application.Models;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class InteractionServices : IInteractionServices
    {
        private readonly IInteractionCommand _command;
        private readonly IInteractionQuery _query;
        private readonly IInteractionMapper _mapper;
        private readonly IInteractionTypeServices _interactionTypeServices;

        public InteractionServices(IInteractionCommand command, IInteractionTypeServices interactionTypeServices, 
            IInteractionQuery query, IInteractionMapper mapper)
        {
            _command = command;
            _interactionTypeServices = interactionTypeServices;
            _query = query;
            _mapper = mapper;
        }
        public async Task<InteractionsResponse> CreateInteraction(CreateInteractionRequest request, Guid id)
        {
            var interaction = new Interaction
            {
                Notes = request.Notes,
                Date = request.Date,
                ProjectID = id,
                interactionType = request.interactionType,
            };
            await _command.InsertInteraction(interaction);
            return new InteractionsResponse
            {
                InteractionID = interaction.InteractionID,
                Notes = request.Notes,
                Date = request.Date,
                ProjectID = id,
                interaction = await _interactionTypeServices.GetById(request.interactionType),
            };
        }
        public async Task<List<InteractionsResponse>> GetAllInteractionsById(Guid id)
        {
            var tasks = await _query.ListGetAllById(id);
            return await _mapper.GetInteractions(tasks);
        }
        public async Task<Interaction> InsertInteraction(Domain.Entities.Interaction interaction)
        {
            await _command.InsertInteraction(interaction);
            throw new NotImplementedException();
        }
    }
}
