using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_POS_System.DAL.Repository;
using Pharmacy_POS_System.Data;
using Pharmacy_POS_System.Entities;
using Pharmacy_POS_System.DAL.Interface;

namespace Pharmacy_POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepo;

        public SalesController(ISaleRepository saleRepo)
        {
            _saleRepo = saleRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var sale = await _saleRepo.Get();

            return Ok(sale);
        }


        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var sale = _saleRepo.Get(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Sale>> Post(Sale sale)
        {
            var data = await _saleRepo.Post(sale);
            return Ok(sale);
        }
    }
}
