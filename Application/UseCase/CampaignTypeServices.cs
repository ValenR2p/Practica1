using Application.IMapper;
using Application.Interface;
using Application.Response;

namespace Application.UseCase
{
    public class CampaignTypeServices : ICampaignTypeServices
    {
        private readonly ICampaignTypeQuery _query;
        private readonly ICampaignTypeCommand _command;
        private readonly IGenericMapper _mapper;

        public CampaignTypeServices(ICampaignTypeQuery query, ICampaignTypeCommand command, IGenericMapper mapper)
        {
            _query = query;
            _command = command;
            _mapper = mapper;
        }
        public async Task<List<GenericResponse>> GetAll()
        {
            var campaingsTypes = await _query.ListGetAll();
            return await _mapper.GetCampaignType(campaingsTypes);
        }
        public async Task<GenericResponse> GetById(int id)
        {
            var campaignType = await _query.GetCampaignTypes(id);
            return await _mapper.GetOneCampaignType(campaignType);
        }
    }
}
