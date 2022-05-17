using AutoMapper;
using DAL;
using DTO;
using System.Linq;

namespace BLL
{
    public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<ActModel, ActResponseDTO>();
			CreateMap<CreateActDTO, ActModel>();
			CreateMap<CreateCategoryDTO, CategoryModel>();
			CreateMap<CategoryModel, CategoryResponseDTO>();
		}
	}
}
