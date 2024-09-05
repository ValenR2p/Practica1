using Application.IMapper;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    //interaction = intereaction.interaction
                    interaction = await _interactionTypeMapper.GetOneInteractionType(interaction.interaction),
                };
                responses.Add(response);
            }
            return await System.Threading.Tasks.Task.FromResult(responses);
        }
    }
}
