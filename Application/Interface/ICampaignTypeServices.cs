﻿using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICampaignTypeServices
    {
        Task<List<GenericResponse>> GetAll();
        Task<GenericResponse> GetById(int id);
    }
}
