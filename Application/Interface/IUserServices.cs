using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserServices
    {
        Task<UserResponse> GetById(int id);
        Task<List<UserResponse>> GetAll();
    }
}
