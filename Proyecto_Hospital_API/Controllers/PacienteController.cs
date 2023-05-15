using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.PacienteDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;
        private readonly PacienteService pacienteSV;



        public PacienteController(ILogger<PacienteController> logger, IMapper _mapper,AppDbContext _db)
        {
            _logger = logger;
            mapper= _mapper;
            db= _db;
            pacienteSV= new PacienteService(_db);
        }

        [HttpGet("GetListPatients")]
        [ProducesResponseType(typeof(List<PacienteMiniDTO>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListPatients()
        {
            var result = await pacienteSV.GetListAsync();
            var resultMap = mapper.Map<List<PacienteMiniDTO>>(result);
            return Ok(resultMap);
        }

        [HttpPost("GetPatientById")]
        [ProducesResponseType(typeof(PacienteMiniDTO),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatientById([FromBody] Guid id)
        {
            var result = await pacienteSV.GetByIdAsync(id);
            var resultMap = mapper.Map<PacienteMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpDelete("DeletePatientById")]
        [ProducesResponseType(typeof(PacienteMiniDTO),StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePatientById([FromBody] Guid id)
        {
            var result = await pacienteSV.DeleteAsync(id);
            var resultMap = mapper.Map<PacienteMiniDTO> (result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditPatient")]
        [ProducesResponseType(typeof(PacienteMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditPatient([FromBody] PacientePostDTO paciente)
        {
            var resultado = await pacienteSV.CheckCapacity(mapper.Map<Paciente>(paciente));
            if(resultado == string.Empty)
            {
                var resultadoBueno = await pacienteSV.AddEditAsync(mapper.Map<Paciente>(paciente));
                var resultadoBuenoMap = mapper.Map<PacienteMiniDTO>(resultadoBueno);
                return Ok(resultadoBuenoMap);
            }
            return BadRequest();
        }


        [HttpPost("GetRandomPatientByDoctorId")]
        [ProducesResponseType(typeof(PacienteMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetRandomPatientByDoctorId([FromBody] Guid id)
        {
            var result = await pacienteSV.GetRandomPatient(id);
            var resultMap = mapper.Map<PacienteMiniDTO>(result);
            return Ok(resultMap);
        }




    }
}
