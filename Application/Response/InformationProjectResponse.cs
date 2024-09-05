using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class InformationProjectResponse
    {
        public ProjectResponse data { get; set; }
        public List<InteractionsResponse> interactions { get; set; }
        public List<TaskResponse> tasks { get; set; }
    }
}
