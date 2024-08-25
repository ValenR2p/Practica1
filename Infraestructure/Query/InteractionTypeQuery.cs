using Application.Interface;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class InteractionTypeQuery : IInteractionTypeQuery
    {
        private readonly ApiContext _apiContext;

        public InteractionTypeQuery(ApiContext context)
        {
            _apiContext = context;
        }
        public List<InteractionType> ListGetAll()
        {
            return _apiContext.InteractionTypes.ToList();

            //throw new NotImplementedException();
        }
    }
}
