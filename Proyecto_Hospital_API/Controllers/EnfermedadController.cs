
using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.EnfermedadDTOs;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.DTO.PacienteDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnfermedadController : ControllerBase
    {
        private readonly ILogger<EnfermedadController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;

        private readonly EnfermedadService enfermedadSV;

        public EnfermedadController(ILogger<EnfermedadController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
            enfermedadSV = new EnfermedadService(db);
        }

        [HttpGet("GetListEnfermedad")]
        [ProducesResponseType(typeof(List<EnfermedadMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListEnfermedad()
        {
            var result = await enfermedadSV.GetListAsync();
            var resultMap = mapper.Map<List<EnfermedadMiniDTO>>(result);
            return Ok(resultMap);
        }


        [HttpPost("GetEnfermedadById")]
        [ProducesResponseType(typeof(EnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAriaById([FromBody] Guid id)
        {
            var result = await enfermedadSV.GetByIdAsync(id);
            var resultMap = mapper.Map<EnfermedadMiniDTO>(result);
            return Ok(resultMap);
        }



        [HttpDelete("DeleteEnfermedadById")]
        [ProducesResponseType(typeof(EnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteEnfermedadById([FromBody] Guid id)
        {
            var result = await enfermedadSV.DeleteAsync(id);
            var resultMap = mapper.Map<AreaMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditEnfermedad")]
        [ProducesResponseType(typeof(EnfermedadMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditEnfermedad([FromBody] EnfermedadPostDTO enfermedad)
        {
            var result = await enfermedadSV.AddEditAsync(mapper.Map<Enfermedad>(enfermedad));
            var resultMap = mapper.Map<EnfermedadMiniDTO>(result);
            return Ok(resultMap);
        }








    }
}
