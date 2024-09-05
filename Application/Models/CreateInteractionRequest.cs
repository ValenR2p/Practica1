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
    public class CreateInteractionRequest
    {
        public int interactionType { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
