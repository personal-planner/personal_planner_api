using AutoMapper;
using DAL.Commands.ActCommands;
using DAL.Entries;
using DTO.ActDTO;
using System.Threading.Tasks;

namespace BLL.Services.ActServices
{
    public class ActService : IActService
    {
        private readonly IActCommand actCommand;
        private readonly IMapper mapper;

        public ActService(IActCommand actCommand)
        {
            this.actCommand = actCommand;
        }

        public async Task<ActResponseDTO> CreateAct(ActRequestDTO model)
        {
            ActModel instanceModel = new ActModel();

            await actCommand.CreateAct(instanceModel);

            return mapper.Map<ActResponseDTO>(instanceModel);
        }
    }
}
