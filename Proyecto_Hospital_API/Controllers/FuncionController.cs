using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.FuncionDTO;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.DTO.PacienteDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;




namespace Proyecto_Hospital_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionController : ControllerBase
    {
        private readonly ILogger<FuncionController> _logger;
        private IMapper mapper;

        private readonly AppDbContext db;
        private readonly FuncionService funcionSV;

        public FuncionController ( ILogger<FuncionController> logger, IMapper _mapper, AppDbContext _db)
        {
            _logger = logger;
            mapper= _mapper;
            db= _db;
            funcionSV = new FuncionService(_db);
        }


        [HttpGet("GetListFunciones")]
        [ProducesResponseType(typeof(List<FuncionMiniDTO>),StatusCodes.Status200OK)]

        public async Task <IActionResult> GetListFunctionsAsync()
        {
            var result = await funcionSV.GetListAsync();
            var resultMap = mapper.Map<List<FuncionMiniDTO>>(result);
            return Ok(resultMap);
        }


        [HttpPost("GetFunctionByID")]
        [ProducesResponseType(typeof(FuncionMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> GetFunctionById([FromBody] Guid id)
        {
            var result = await funcionSV.GetByIdAsync(id);
            var resultMap = mapper.Map<FuncionMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpDelete("DeleteFuncionById")]
        [ProducesResponseType(typeof(FuncionMiniDTO),StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFunctionById([FromBody] Guid id)
        {
            var result = await funcionSV.DeleteAsync(id);
            var resultMap = mapper.Map<FuncionMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpPost("AddEditFunction")]
        [ProducesResponseType(typeof(FuncionMiniDTO),StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditFunction([FromBody] FuncionPostDTO funcion)
        {
            var result = await funcionSV.AddEditAsync(mapper.Map<Funcion>(funcion));
            var resultMap = mapper.Map<FuncionMiniDTO> (result);
            return Ok(resultMap);
        }


    }
}
