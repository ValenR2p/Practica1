using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITaskStatusQuery
    {
        Task<List<Domain.Entities.TaskStatus>> ListGetAll();
        Task<Domain.Entities.TaskStatus> GetById(int id);
    }
}
