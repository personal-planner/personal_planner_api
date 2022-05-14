using BLL.Services.ActServices;
using DTO.ActDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActController : ControllerBase
    {
        private  IActService actService { get; }

        public ActController(IActService actService)
        {
            this.actService = actService;

        }

        public async Task<ActionResult<ActResponseDTO>> CreateAct([FromBody] ActRequestDTO model)
        {
            await actService.CreateAct(model);

            return Ok(new ActResponseDTO());
        }
    }
}
