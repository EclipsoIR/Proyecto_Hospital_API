using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.DTO.PersonaDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {

        private readonly ILogger<PersonaController> _logger;

        private IMapper mapper;

        private readonly AppDbContext db;

        private readonly PersonaService personaSV;

        public PersonaController(ILogger<PersonaController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper = _mapper;
            db = _db;
            personaSV = new PersonaService(db, _mapper);
        }



        [HttpGet("GetListPersona")]
        [ProducesResponseType(typeof(List<PersonaMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListPersona()
        {
            var result = await personaSV.GetListAsync();
            var resultMap = mapper.Map<List<PersonaMiniDTO>>(result);
            return Ok(resultMap);
        }

        [HttpPost("GetPersonaById")]
        [ProducesResponseType(typeof(PersonaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPersonaById([FromBody] Guid id)
        {
            var result = await personaSV.GetByIdAsync(id);
            var resultMap = mapper.Map<PersonaMiniDTO>(result);
            return Ok(resultMap);
        }


        [HttpDelete("DeletePersonaById")]
        [ProducesResponseType(typeof(PersonaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeletePersonaById([FromBody] Guid id)
        {
            var result = await personaSV.DeleteAsync(id);
            var resultMap = mapper.Map<PersonaMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditPersona")]
        [ProducesResponseType(typeof(PersonaMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditPersona([FromBody] PersonaPostDTO persona)
        {
            var result = await personaSV.AddEditAsync(mapper.Map<Persona>(persona));
            var resultMap = mapper.Map<PersonaMiniDTO>(result);
            return Ok(resultMap);
        }



        [HttpGet("TablePersonaTable")]
        [ProducesResponseType(typeof(DataTableDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetDataTable(int page)
        {
            var result = await personaSV.GetPersonListPerPage(page);
            return Ok(result);
        }



    }
}
