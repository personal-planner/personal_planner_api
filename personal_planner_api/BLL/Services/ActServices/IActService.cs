using DTO.ActDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ActServices
{
    public interface IActService
    {
        public Task<ActResponseDTO> CreateAct(ActRequestDTO model);
    }
}
