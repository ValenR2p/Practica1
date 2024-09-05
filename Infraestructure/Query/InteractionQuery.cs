using Application.Interface;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class InteractionQuery : IInteractionQuery
    {
        private readonly ApiContext _apiContext;
        public InteractionQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<List<Domain.Entities.Interaction>> ListGetAllById(Guid id)
        {
            var interactions = await _apiContext.Interactions.
                Include(s => s.interaction).
                Where(s => s.ProjectID == id).ToListAsync();
            return interactions;
        }
    }
}
