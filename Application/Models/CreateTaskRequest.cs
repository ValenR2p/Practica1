using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedTo { get; set; }
        public int Status { get; set; }

    }
}
