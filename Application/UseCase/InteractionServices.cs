using Application.Exceptions;
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
        private readonly IInteractionTypeQuery _interactionTypeQuery;
        public InteractionServices(IInteractionCommand command, IInteractionQuery query,
            IInteractionMapper mapper, IInteractionTypeQuery interactionTypeQuery)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _interactionTypeQuery = interactionTypeQuery;
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
            var interactionTypeSearch = await _interactionTypeQuery.GetById(interaction.interactionType);
            if (interaction.Notes == "string" || interaction.Notes == "" || interaction.interactionType == 0)
            {
                throw new BadRequestException("The Request contains a non acceptable value");
            }
            else if (interactionTypeSearch == null)
            {
                throw new BadRequestException("There is no Interaction Type with the chosen ID");
            }
            await _command.InsertInteraction(interaction);
            return await _mapper.GetOneInteraction(interaction);
        }


        public async Task<List<InteractionsResponse>> GetAllInteractionsById(Guid id)
        {
            var tasks = await _query.ListGetAllById(id);
            return await _mapper.GetInteractions(tasks);
        }


        public async System.Threading.Tasks.Task InsertInteraction(Domain.Entities.Interaction interaction)
        {
            await _command.InsertInteraction(interaction);
        }
    }
}
