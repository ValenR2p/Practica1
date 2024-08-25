using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IInteractionTypeCommand
    {
        public System.Threading.Tasks.Task InsertInteractionType(InteractionType campaignType);
    }
}