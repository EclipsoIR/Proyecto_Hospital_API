using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.EnfermedadDTOs;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.DTO.PacienteEnfermedadDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteEnfermedadController :ControllerBase
    {
        private readonly ILogger <PacienteEnfermedadController> _logger;

        private IMapper mapper;

        private readonly AppDbContext db;

        private readonly PacienteEnfermedadService pacienteEnfermedadSV;

        public PacienteEnfermedadController(ILogger<PacienteEnfermedadController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
            pacienteEnfermedadSV = new PacienteEnfermedadService(db);
        }

        [HttpGet("GetListPacienteEnfermedad")]
        [ProducesResponseType(typeof(List<PacienteEnfermedadMiniDTO>), StatusCodes.Status200OK)]

        public async Task <IActionResult> GetListPacienteEnfermedad()
        {
            var result = await pacienteEnfermedadSV.GetListAsync();
            var resuktMap = mapper.Map<List<PacienteEnfermedadMiniDTO>>(result);
            return Ok(resuktMap);
        }

        [HttpPost("GetPacienteEnfermedaddById")]
        [ProducesResponseType(typeof(PacienteEnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPacienteEnfermedadById([FromBody] Guid id)
        {
            var result = await pacienteEnfermedadSV.GetByIdAsync(id);
            var resultMap = mapper.Map<PacienteEnfermedadMiniDTO>(result);
            return Ok(resultMap);
        }



        [HttpDelete("DeletePacienteEnfermedadById")]
        [ProducesResponseType(typeof(PacienteEnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeletePacienteEnfermedadById([FromBody] Guid id)
        {
            var result = await pacienteEnfermedadSV.DeleteAsync(id);
            var resultMap = mapper.Map<PacienteEnfermedadMiniDTO>(result);
            return Ok(resultMap);
        }


        [HttpPost("AddEditPacienteEfermedad")]
        [ProducesResponseType(typeof(PacienteEnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditPacienteEfermedad([FromBody] PacienteEnfermedadPostDTO enfermedad)
        {
            var result = await pacienteEnfermedadSV.AddEditAsync(mapper.Map<PacienteEnfermedad>(enfermedad));
            var resultMap = mapper.Map<PacienteEnfermedadMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("GetPacienteEnfermedadByDates")]
        [ProducesResponseType(typeof(List<Paciente>),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPacienteEnfermedadByDates([FromBody]DateTime startDate, DateTime endDate)
        {
            var result = await pacienteEnfermedadSV.GetPacienteEnfermedadByDates(startDate, endDate);
            return Ok(result);
        }


        [HttpGet("GetHospitalWithMostPatient")]
        [ProducesResponseType(typeof(HospitalEnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetHospitalWithMostPatient()
        {
            var result = await pacienteEnfermedadSV.GetHospitalWithMostPatient();
            var hospitalEnfermedad = new HospitalEnfermedadMiniDTO()
            {
                Enfermedad = mapper.Map<EnfermedadMiniDTO>(result.enf),
                Hospital = result.hsp,
            };

            return Ok(hospitalEnfermedad);
        }

    }
}
