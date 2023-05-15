using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.DTO.PacienteDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase
    {

        private readonly ILogger<AreaController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;

        private readonly AreaService areaSV;

        public AreaController(ILogger<AreaController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
            areaSV = new AreaService(db);
        }



        [HttpGet("GetListArea")]
        [ProducesResponseType(typeof(List<AreaMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListArea()
        {
            var result = await areaSV.GetListAsync();
            var resultMap = mapper.Map<List<AreaMiniDTO>>(result);
            return Ok(resultMap);
        }


        [HttpPost("GetAreaById")]
        [ProducesResponseType(typeof(AreaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAriaById([FromBody] Guid id)
        {
            var result = await areaSV.GetByIdAsync(id);
            var resultMap = mapper.Map<AreaMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpDelete("DeleteAriaById")]
        [ProducesResponseType(typeof(AreaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAreaById([FromBody] Guid id)
        {
            var result = await areaSV.DeleteAsync(id);
            var resultMap = mapper.Map<AreaMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditAria")]
        [ProducesResponseType(typeof(AreaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditAria([FromBody] AreaPostDTO area)
        {
            var result = await areaSV.AddEditAsync(mapper.Map<Area>(area));
            var resultMap = mapper.Map<AreaMiniDTO>(result);
            return Ok(resultMap);
        }



        [HttpPost("TakeAreaForDoctar")]
        [ProducesResponseType(typeof(AreaMiniDTO),StatusCodes.Status200OK)]


        public async Task<IActionResult> TakeAreaForDoctar([FromBody] Guid id)
        {
            var result = await areaSV.TakeAreaForDoctar(id);
            var resultMap = mapper.Map<AreaMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("GetAreasFunctionsHospitalPatient")]
        [ProducesResponseType(typeof(List<AreaMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAreasFunctionsHospitalPatient([FromBody] PacientePostDTO paciente)
        {
            var result = await areaSV.GetAreasFunctionsHospitalPatient(mapper.Map<Paciente>(paciente));
            var resutlMap = mapper.Map<List<AreaMiniDTO>>(result);
            return Ok(resutlMap);
        }

    }
}
