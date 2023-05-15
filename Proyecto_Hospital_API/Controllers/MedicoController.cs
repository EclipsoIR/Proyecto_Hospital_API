using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ILogger<MedicoController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;
        private readonly MedicoService medicoSV;

        public MedicoController(ILogger<MedicoController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper= _mapper;
            db= _db;
            medicoSV = new MedicoService(_db);
        }

        [HttpGet("GetListMedicos")]
        [ProducesResponseType(typeof(List<MedicoMiniDTO>),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListMedicoAsync()
        {
            var result = await medicoSV.GetListAsync();
            var resultMap = mapper.Map<List<MedicoMiniDTO>>(result);
            return Ok(resultMap);
        }


        [HttpPost("GetMedicoById/{id}")]
        [ProducesResponseType(typeof(MedicoMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetMedicoById([FromBody] Guid id)
        {
            var result = await medicoSV.GetByIdAsync(id);
            var resultMap = mapper.Map<MedicoMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpDelete("DeleteMedicoById")]
        [ProducesResponseType(typeof(MedicoMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteMedicoById([FromBody] Guid id)
        {
            var result = await medicoSV.DeleteAsync(id);
            var resultMap = mapper.Map<MedicoMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditMedico")]
        [ProducesResponseType(typeof(MedicoMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditMedico([FromBody] MedicoPostDTO medico)
        {
            var result = await medicoSV.CheckCapacity(mapper.Map<Medico>(medico));
            var result2 = await medicoSV.CheckCapacityArea(mapper.Map<Medico>(medico));
            if(string.IsNullOrEmpty(result) && string.IsNullOrEmpty(result2))
            {
                var resultBueno = await medicoSV.AddEditAsync(mapper.Map<Medico>(medico));
                var resultBuenoMap = mapper.Map<MedicoMiniDTO>(resultBueno);
                return Ok(resultBuenoMap);
            }
            return BadRequest(string.IsNullOrEmpty(result)?result2:result);
        }



        [HttpPost("ShowDoctorsPatient")]
        [ProducesResponseType(typeof(List<MedicoMiniDTO>),StatusCodes.Status200OK)]

        public async Task<IActionResult> ShowDoctorsPatient()
        {
            var resultado = await medicoSV.ShowDoctorsPatient();
            var resultadoMap = mapper.Map<List<MedicoMiniDTO>>(resultado);
            return Ok(resultadoMap);
        }

    }
}
