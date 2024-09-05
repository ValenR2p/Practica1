using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class TaskResponse
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public GenericResponse TaskStatus { get; set; }
        public UserResponse User { get; set; }
    }
}
