using Application.IMapper;
using Application.Interface;
using Application.Response;

namespace Application.UseCase
{
    public class InteractionTypeServices : IInteractionTypeServices
    {
        private readonly IInteractionTypeQuery _query;
        private readonly IGenericMapper _mapper;

        public InteractionTypeServices(IInteractionTypeQuery query, IGenericMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<List<GenericResponse>> GetAll()
        {
            var interactionTypes = await _query.ListGetAll();
            return await _mapper.GetInteractionType(interactionTypes);
        }
        public async Task<GenericResponse> GetById(int id)
        {
            var interactionType = await _query.GetById(id);
            return await _mapper.GetOneInteractionType(interactionType);
        }
    }
}
