using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMapper
{
    public interface IInformationProjectMapper
    {
        Task<InformationProjectResponse> GetProject(Project project);
    }
}
