using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersPageBackend.Domain;
using TeachersPageBackend.Services.Materii;

namespace TeachersPageBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriiController : ControllerBase
    {
        private readonly IMateriiService _materiiService;

        public MateriiController(IMateriiService materiiService)
        {
            _materiiService = materiiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterii()
        {
            List<Materie> materii = await _materiiService.GetAll();
            return Ok(materii);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterie([FromBody] Materie materie)
        {
            if (materie == null)
            {
                return BadRequest("Materie cannot be null");
            }
            await _materiiService.Add(materie);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMaterie([FromBody] Materie materie)
        {
            if (materie == null)
            {
                return BadRequest("Materie cannot be null");
            }

            bool result = await _materiiService.Update(materie);
            if (!result)
                return NotFound("Materie not found or property didn't change");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterie(Guid id)
        {
            if (id == null)
                return BadRequest("Id cannot be null");

            bool result = await _materiiService.Remove(id);
            if (!result)
                return NotFound("Materie not found");
            return Ok();
        }
    }
}
