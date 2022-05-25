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
        private readonly IUserQuery userQuery;

        public CategoryService(ICategoryQuery categoryQuery, IMapper mapper, ICategoryCommand categoryCommand, IUserQuery userQuery)
        {
            this.categoryCommand = categoryCommand;
            this.mapper = mapper;
            this.categoryQuery = categoryQuery;
            this.userQuery = userQuery;
        }

        public CategoryResponseDTO CreateCategory(CreateCategoryDTO model)
        {
            var instanceModel = mapper.Map<CategoryModel>(model);

            instanceModel.User = userQuery.GetByName(model.UserName);

            categoryCommand.CreateCategory(instanceModel);

            return mapper.Map<CategoryResponseDTO>(instanceModel);
        }

        public CategoryResponseDTO ChangeCategory(ChangeCategoryDTO model)
        {
            var instanceModel = mapper.Map<CategoryModel>(model);

            categoryCommand.ChangeCategory(instanceModel);

            return mapper.Map<CategoryResponseDTO>(instanceModel);
        }

        public IEnumerable<CategoryResponseDTO> GetCategories(string userId)
        {
            return mapper.Map<IEnumerable<CategoryResponseDTO>>(categoryQuery.GetCategories(userId));
        }
    }
}
