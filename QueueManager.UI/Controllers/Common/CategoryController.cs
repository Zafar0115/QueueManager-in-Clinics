using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.DTOs.AdminDTO.PermissionDTO;
using QueueManager.Application.DTOs.Common.CategoryDTO;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Models;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using QueueManager.UI.Controllers.ApiController;
using System.ComponentModel.DataAnnotations;

namespace QueueManager.UI.Controllers.common
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase<Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseCore<CategoryOutcomingDTO>>> Create([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO);
            var validationResult=_validator.Validate(category);
            if(!validationResult.IsValid)
                return BadRequest(new ResponseCore<Category>(false,validationResult.Errors));
            Category? addedCategory=await _categoryRepository.AddAsync(category);
            if(addedCategory is null)
                return BadRequest(new ResponseCore<CategoryOutcomingDTO>(false,"something wrong with database"));
            CategoryOutcomingDTO? mappedResult = _mapper.Map<CategoryOutcomingDTO>(addedCategory);
            return Ok(new ResponseCore<CategoryOutcomingDTO>(mappedResult));
        }


        [HttpGet("getbyid")]
        public async Task<ActionResult<ResponseCore<CategoryOutcomingDTO>>> GetById([FromQuery] Guid id)
        {
            Category? category = await _categoryRepository.GetById(id);
            if (category is null) return NotFound(new ResponseCore<CategoryOutcomingDTO>(false, "category not found"));
            var mappedResult=_mapper.Map<CategoryOutcomingDTO>(category);
            return Ok(new ResponseCore<CategoryOutcomingDTO>(mappedResult));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<CategoryOutcomingDTO>>> GetAll()
        {
            IEnumerable<Category> categoories = await _categoryRepository.GetAll();
            var mappedResult=_mapper.Map<IEnumerable<CategoryOutcomingDTO>>(categoories);
            return Ok(new PaginatedList<CategoryOutcomingDTO>(mappedResult.AsQueryable(),5,5,5));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseCore<CategoryOutcomingDTO>>> Remove([FromQuery] Guid id)
        {
            Category? deletedCategory = await _categoryRepository.RemoveAsync(id);
            if (deletedCategory is null)
                return BadRequest(new ResponseCore<CategoryOutcomingDTO>(false, $"Category with ID: \"{id}\" not found"));
            var mappedResult = _mapper.Map<CategoryOutcomingDTO>(deletedCategory);
            return Ok(new ResponseCore<CategoryOutcomingDTO>(mappedResult));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseCore<CategoryOutcomingDTO>>> Update([FromBody] CategoryOutcomingDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            var validationResult = _validator.Validate(category);
            if (!validationResult.IsValid)
                return BadRequest(new ResponseCore<CategoryOutcomingDTO>(false, validationResult.Errors));

            var updated = await _categoryRepository.UpdateAsync(category);
            if (updated is null)
                return BadRequest(new ResponseCore<CategoryOutcomingDTO>(false, $"Object ID: {category.CategoryId} not found to update"));
            var mappedResult = _mapper.Map<CategoryOutcomingDTO>(updated);
            return Ok(new ResponseCore<CategoryOutcomingDTO>(mappedResult));
        }

    }
}
