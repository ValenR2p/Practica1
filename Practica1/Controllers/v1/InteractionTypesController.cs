﻿using Application.Interface;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypeServices _services;
        public InteractionTypesController(IInteractionTypeServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GenericResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result)
            {
                StatusCode = 200
            };
        }
    }
}
