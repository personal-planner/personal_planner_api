using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService { get; }

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseDTO>> GetCategories([FromQuery] Guid userId)
        {
            return Ok(categoryService.GetCategories(userId));
        }

        [HttpPost]
        public ActionResult<CategoryResponseDTO> CreateCategory([FromBody] CreateCategoryDTO data)
        {
            return Ok(categoryService.CreateCategory(data));
        }
    }
}
