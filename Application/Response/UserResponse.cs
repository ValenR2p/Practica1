﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class UserResponse
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
