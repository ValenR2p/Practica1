using Application.Response;
using Domain.Entities;

namespace Application.IMapper
{
    public interface IInformationProjectMapper
    {
        Task<InformationProjectResponse> GetProject(Project project);
    }
}
