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
        public IEnumerable<ActResponseDTO> GetActs(Guid id);
        public PaginatedActsResponceDTO GetPaginatedActs(PaginatedActsDTO data);
    }
}
