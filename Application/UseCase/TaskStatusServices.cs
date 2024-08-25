using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    internal class TaskStatusServices
    {
        private readonly ITaskStatusQuery _query;
        private readonly ITaskStatusCommand _command;

        public TaskStatusServices(ITaskStatusQuery query, ITaskStatusCommand command)
        {
            _query = query;
            _command = command;
        }
        public async Task<List<Domain.Entities.TaskStatus>> GetAll()
        {
            var campaignTypes = new List<Domain.Entities.TaskStatus>
            {
                new Domain.Entities.TaskStatus { Name = "SEO" },
                new Domain.Entities.TaskStatus { Name = "PPC" },
                new Domain.Entities.TaskStatus { Name = "Social Media" },
                new Domain.Entities.TaskStatus { Name = "Email Marketin" }
            };
            foreach (var campaignType in campaignTypes)
            {
                await _command.InsertCampaignType(campaignType);
            }

            return _query.ListGetAll();
            //return campaignTypes;
            //throw new NotImplementedException();
        }
    }
}
