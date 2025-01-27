using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_POS_System.DAL.Interface;
using Pharmacy_POS_System.Entities;

namespace Pharmacy_POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository repository)
        {
            _customerRepo = repository;
        }

        [HttpGet, Route("Get")]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerRepo.Get();
            return Ok(customer);
        }

        [HttpGet, Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerRepo.Get(id);
            return Ok(customer);
        }

        [HttpPost, Route("Post")]
        public async Task<IActionResult> Post(Customer customer)
        {
            var data = await _customerRepo.Post(customer);
            return Ok(customer);
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerRepo.Delete(id);
            return Ok(data);
        }

        [HttpPut, Route("Put/{id}")]
        public async Task<IActionResult> Put(Customer customer, int id)
        {
            var data = await _customerRepo.Put(id, customer);
            return Ok(data);
        }
    }
}
