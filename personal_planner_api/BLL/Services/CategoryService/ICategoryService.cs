﻿using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryResponseDTO> GetCategories(Guid userId);
        public CategoryResponseDTO CreateCategory(CreateCategoryDTO model);
        public CategoryResponseDTO ChangeCategory(ChangeCategoryDTO model);
    }
}
