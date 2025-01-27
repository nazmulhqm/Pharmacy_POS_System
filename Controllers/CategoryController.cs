using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository repository)
        {
            _categoryRepo = repository;
        }

        [HttpGet, Route("Get")]
        public async Task<IActionResult> Get()
        {
            var category = await _categoryRepo.Get();
            return Ok(category);
        }

        [HttpGet, Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepo.Get(id);
            return Ok(category);
        }

        [HttpPost, Route("Post")]
        public async Task<IActionResult> Post(Category category)
        {
            var data = await _categoryRepo.Post(category);
            if (data != null)
            {
                return Ok(category);
            }
            return Content("Category Already Exists!!!");
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoryRepo.Delete(id);
            return Ok(data);
        }

        [HttpPut, Route("Put/{id}")]
        public async Task<IActionResult> Put(Category category, int id)
        {
            var data = await _categoryRepo.Put(id, category);
            return Ok(data);
        }
    }
}
