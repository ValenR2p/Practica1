using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITaskCommand
    {
        public System.Threading.Tasks.Task InsertTask(Domain.Entities.Task task);
        public System.Threading.Tasks.Task UpdateTask(Domain.Entities.Task task);
    }
}
