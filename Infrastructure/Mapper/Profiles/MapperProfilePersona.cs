using AutoMapper;
using Infrastructure.DTO.PersonaDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfilePersona : Profile
    {
        public MapperProfilePersona() 
        {
            CreateMap<Persona, PersonaDTO>()
                .ReverseMap();
            CreateMap<Persona, PersonaMiniDTO>()
                .ReverseMap();
            CreateMap<Persona, PersonaPostDTO>()
                .ReverseMap();
            CreateMap<PersonaDTO, PersonaMiniDTO>()
                .ReverseMap();
            CreateMap<DataTableDTO, PersonaMiniDTO>()
                .ReverseMap();
        }
    }
}
