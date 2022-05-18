using AutoMapper;
using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommand categoryCommand;
        private readonly ICategoryQuery categoryQuery;
        private readonly IMapper mapper;

        public CategoryService(ICategoryQuery categoryQuery, IMapper mapper, ICategoryCommand categoryCommand)
        {
            this.categoryCommand = categoryCommand;
            this.mapper = mapper; 
            this.categoryQuery = categoryQuery;
        }

        public CategoryResponseDTO CreateCategory(CreateCategoryDTO model)
        {
            var instanceModel = mapper.Map<CategoryModel>(model);

            categoryCommand.CreateCategory(instanceModel);

            return mapper.Map<CategoryResponseDTO>(instanceModel);
        }

        public CategoryResponseDTO ChangeCategory(ChangeCategoryDTO model)
        {
            var instanceModel = mapper.Map<CategoryModel>(model);

            categoryCommand.ChangeCategory(instanceModel);

            return mapper.Map<CategoryResponseDTO>(instanceModel);
        }

        public IEnumerable<CategoryResponseDTO> GetCategories(Guid userId)
        {
            return mapper.Map<IEnumerable<CategoryResponseDTO>>(categoryQuery.GetCategories(userId));
        }
    }
}
