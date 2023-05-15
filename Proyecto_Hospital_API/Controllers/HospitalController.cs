using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;

        private readonly HospitalService hospitalSV;

        public HospitalController (ILogger<HospitalController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper= _mapper;
            db= _db;
            hospitalSV= new HospitalService(db);
        }

        [HttpGet("GetListHospital")]
        [ProducesResponseType(typeof(List<HospitalMiniDTO>),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListHospitalAsync()
        {
            var result = await hospitalSV.GetListAsync();
            var resultMap = mapper.Map<List<HospitalMiniDTO>>(result);
            return Ok(resultMap);
        }

        [HttpPost("GetHospitaById/{id}")]
        [ProducesResponseType(typeof(HospitalMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetHospitalByIdAsync(Guid id)
        {
            var result = await hospitalSV.GetByIdAsync(id);
            var resultMap = mapper.Map<HospitalMiniDTO>(result);
            return Ok(resultMap);
        }


        [HttpDelete("DeleteHospitaById/{id}")]
        [ProducesResponseType(typeof(HospitalMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteHospitalByIdAsync(Guid id)
        {
            var result = await hospitalSV.DeleteAsync(id);
            var resultMap = mapper.Map<HospitalMiniDTO> (result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditHospital")]
        [ProducesResponseType(typeof(HospitalMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditHospital([FromBody] HospitalPostDTO hospital)
        {
            var result = await hospitalSV.AddEditAsync(mapper.Map<Hospital>(hospital));
            var resultMap = mapper.Map<HospitalMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpGet("GetPacientesMedicosActuales")]
        [ProducesResponseType(typeof(List<HospitalMiniDTO>),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPacientesMedicosActuales()
        {
            var result = await hospitalSV.GetPacientesMedicosActuales();
            return Ok(result);
        }

        [HttpPost("GetHospitalByReason")]
        [ProducesResponseType(typeof(List<HospitalMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetHospitalByReason([FromBody] MotivoPaciente motivo)
        {
            var result = await hospitalSV.GetHospitalByReason(motivo);
            var resultMap = mapper.Map<List<HospitalMiniDTO>>(result);
            return Ok(resultMap);
        }


    }
}
