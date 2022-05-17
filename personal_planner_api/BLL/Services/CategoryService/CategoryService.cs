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

        public CategoryResponseDTO CreateCategory(CreateCategoryDTO catData)
        {
            var model = mapper.Map<CategoryModel>(catData);

            categoryCommand.CreateCategory(model);

            return mapper.Map<CategoryResponseDTO>(model);
        }

        public IEnumerable<CategoryResponseDTO> GetCategories(Guid userId)
        {
            return mapper.Map<IEnumerable<CategoryResponseDTO>>(categoryQuery.GetCategories(userId));
        }
    }
}
