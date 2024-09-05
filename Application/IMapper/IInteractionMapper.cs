using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMapper
{
    public interface IInteractionMapper
    {
        Task<List<InteractionsResponse>> GetInteractions(List<Interaction> interactions);
    }
}
