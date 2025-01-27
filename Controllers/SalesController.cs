﻿using Microsoft.AspNetCore.Http;
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
        private readonly PharmacyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ISaleRepository _saleRepo;

        public SalesController(PharmacyDbContext context, IWebHostEnvironment hostEnvironment, ISaleRepository saleRepo)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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

        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(int id, Sale sale)
        {
            var data = await _saleRepo.Put(id, sale);
            return Ok(data);
        }
    }
}
