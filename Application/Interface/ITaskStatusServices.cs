﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    internal interface ITaskStatusServices
    {
        Task<List<Domain.Entities.TaskStatus>> GetAll();
    }
}