using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Entities;
using Pharmacy_POS_System.Migrations;

namespace Pharmacy_POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandRepository _iRepo;

        public BrandController(IBrandRepository repository)
        {
            _iRepo = repository;
        }

        [HttpGet, Route("Get")]
        public async Task<IActionResult> Get()
        {
            var brands = await _iRepo.Get();
            return Ok(brands);
        }

        [HttpGet, Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _iRepo.Get(id);
            return Ok(brand);
        }

        [HttpPost, Route("Post")]
        public async Task<IActionResult> Post(Brand brand)
        {
            var data = await _iRepo.Post(brand);
            return Ok(brand);
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _iRepo.Delete(id);
            return Ok(data);
        }

        [HttpPut, Route("Put/{id}")]
        public async Task<IActionResult> Put(Brand brand, int id)
        {
            var data = await _iRepo.Put(id, brand);
            return Ok(data);
        }
    }
}
