using BLL;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActController : ControllerBase
    {
        private IActService actService { get; }

        public ActController(IActService actService)
        {
            this.actService = actService;

        }

        [HttpPost("createact")]
        public ActionResult<ActResponseDTO> CreateAct([FromBody] CreateActDTO model)
        {
            model.UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(actService.CreateAct(model));
        }

        [HttpPost("getpaginatedacts")]
        public ActionResult<PaginatedActsResponceDTO> GetPaginatedActs(PaginatedActsDTO model)
        {
            model.UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(actService.GetPaginatedActs(model));
        }
    }
}
