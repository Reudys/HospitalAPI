using HospitalAPI.Interfaces;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _service;

        public SpecializationController(ISpecializationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specializations = await _service.GetAllAsync();
            return Ok(specializations);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Specialization specialization)
        {
            if (specialization == null)
            {
                return BadRequest();
            }
            var createdSpecialization = await _service.CreateAsync(specialization);
            return CreatedAtAction(nameof(GetAll), new { id = createdSpecialization.Id }, createdSpecialization);
        }
    }
}
