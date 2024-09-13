using Application.IMapper;
using Application.Response;

namespace Application.Mappers
{
    public class InteractionMapper : IInteractionMapper
    {
        private readonly IGenericMapper _interactionTypeMapper;

        public InteractionMapper(IGenericMapper interactionTypeMapper)
        {
            _interactionTypeMapper = interactionTypeMapper;
        }

        public async Task<List<InteractionsResponse>> GetInteractions(List<Domain.Entities.Interaction> intereactions)
        {
            List<InteractionsResponse> responses = new List<InteractionsResponse>();
            foreach (var interaction in intereactions)
            {
                var response = new InteractionsResponse
                {
                    InteractionID = interaction.InteractionID,
                    Notes = interaction.Notes,
                    Date = interaction.Date,
                    ProjectID = interaction.ProjectID,
                    interaction = await _interactionTypeMapper.GetOneInteractionType(interaction.interaction),
                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
