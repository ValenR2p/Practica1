using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class InteractionTypeServices : IInteractionTypeServices
    {
        private readonly IInteractionTypeQuery _query;
        private readonly IInteractionTypeCommand _command;

        public InteractionTypeServices(IInteractionTypeQuery query, IInteractionTypeCommand command)
        {
            _query = query;
            _command = command;
        }
        public async Task<List<InteractionType>> GetAll()
        {
            var interactionTypes = new List<InteractionType>
            {
                new InteractionType { Name = "Initial Meeting" },
                new InteractionType { Name = "Phone call" },
                new InteractionType { Name = "Email" },
                new InteractionType { Name = "Presentation of Results" }
            };
            foreach (var interactionType in interactionTypes)
            {
                await _command.InsertInteractionType(interactionType);
            }

            return _query.ListGetAll();
            //return campaignTypes;
            //throw new NotImplementedException();
        }
    }
}
