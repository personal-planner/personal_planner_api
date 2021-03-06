using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IActService
    {
        public ActResponseDTO CreateAct(CreateActDTO model);
        public ActResponseDTO ChangeAct(ChangeActDTO model);
        public IEnumerable<ActResponseDTO> GetActs(string id);
        public PaginatedActsResponceDTO GetPaginatedActs(PaginatedActsDTO data);
    }
}
