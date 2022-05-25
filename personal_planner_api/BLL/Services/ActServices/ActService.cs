using AutoMapper;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ActService : IActService
    {
        private readonly IActCommand actCommand;
        private readonly IActQuery actQuery;
        private readonly IMapper mapper;
        private readonly IUserQuery userQuery;

        public ActService(IActCommand actCommand, IMapper mapper, IActQuery actQuery, IUserQuery userQuery)
        {
            this.actCommand = actCommand;
            this.mapper = mapper;
            this.actQuery = actQuery;
            this.userQuery = userQuery;
        }

        public ActResponseDTO CreateAct(CreateActDTO model)
        {
            ActModel instanceModel = mapper.Map<ActModel>(model);

            instanceModel.User = userQuery.GetByName(model.UserName);

            actCommand.CreateAct(instanceModel);

            return mapper.Map<ActResponseDTO>(instanceModel);
        }

        public ActResponseDTO ChangeAct(ChangeActDTO model)
        {
            ActModel instanceModel = mapper.Map<ActModel>(model);

            actCommand.ChangeAct(instanceModel);

            return mapper.Map<ActResponseDTO>(instanceModel);
        }

        public IEnumerable<ActResponseDTO> GetActs(string id)
        {
            return mapper.Map<IEnumerable<ActResponseDTO>>(actQuery.GetActsByUserId(id));
        }
        public PaginatedActsResponceDTO GetPaginatedActs(PaginatedActsDTO data)
        {
            var responce = new PaginatedActsResponceDTO();

            var acts = actQuery.GetActsByUserName(data.UserName);

            if (data.Filter != null)
            {
                acts = acts.Where(a => a.Title.Contains(data.Filter));
            }

            if(data.CategoriesId != null)
            {
                acts = acts.Where(c => data.CategoriesId.Any(ci => ci == c.Category.Id));
            }

            responce.Total = acts.Count();
            acts = acts.Skip((data.CurrentPage - 1) * data.PageSize).Take(data.PageSize);
            responce.HasNext = responce.Total > data.CurrentPage * data.PageSize;
            responce.Acts = mapper.Map<IEnumerable<ActResponseDTO>>(acts.ToList());
            responce.PageSize = responce.Acts.Count();
            return responce;
        }
    }
}
