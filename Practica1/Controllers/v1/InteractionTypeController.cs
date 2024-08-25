using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica1.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionTypeController : ControllerBase
    {
        private readonly IInteractionTypeServices _services;
        public InteractionTypeController(IInteractionTypeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();

            //return Enumerable.Range(1, 5).Select(index => new CampaignType
            //{
            //    Id = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),

            //    Name = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            return new JsonResult(result);
        }
    }
}
