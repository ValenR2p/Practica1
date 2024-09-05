using Application.Models;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IInteractionServices
    {
        Task<Domain.Entities.Interaction> InsertInteraction(Domain.Entities.Interaction interaction);
        Task<InteractionsResponse> CreateInteraction(CreateInteractionRequest request, Guid id);
        Task<List<InteractionsResponse>> GetAllInteractionsById(Guid id);
    }
}
