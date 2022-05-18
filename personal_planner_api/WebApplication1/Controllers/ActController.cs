using BLL;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        public ActionResult<ActResponseDTO> CreateAct([FromBody] CreateActDTO model)
        {
            actService.CreateAct(model);

            return Ok(new ActResponseDTO());
        }

        [HttpPost("getpaginatedacts")]
        public ActionResult<PaginatedActsResponceDTO> GetPaginatedActs(PaginatedActsDTO settings)
        {
            return Ok(actService.GetPaginatedActs(settings));
        }
    }
}
