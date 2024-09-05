using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class InteractionTypeQuery : IInteractionTypeQuery
    {
        private readonly ApiContext _apiContext;
        public InteractionTypeQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public async Task<List<InteractionType>> ListGetAll()
        {
            return await _apiContext.InteractionTypes.ToListAsync();
        }
        public async Task<InteractionType> GetById(int id)
        {
            var interactionType = await _apiContext.InteractionTypes.FindAsync(id);
            return interactionType;
        }
    }
}
