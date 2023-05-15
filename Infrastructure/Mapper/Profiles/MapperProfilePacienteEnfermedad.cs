using AutoMapper;
using Infrastructure.DTO.PacienteDTOs;
using Infrastructure.DTO.PacienteEnfermedadDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfilePacienteEnfermedad : Profile
    {

        public MapperProfilePacienteEnfermedad()
        {
            CreateMap<PacienteEnfermedad, PacienteEnfermedadDTO>()
                .ForMember(dst => dst.EnfermedadNombre, options => options.MapFrom(src => src.Enfermedad.Nombre))
                .ForMember(dst => dst.EnfermedadRiesgo, options => options.MapFrom(src => src.Enfermedad.Riesgo))
                .ReverseMap();

            CreateMap<PacienteEnfermedad, PacienteEnfermedadMiniDTO>()
                .ForMember(dst => dst.EnfermedadNombre, options => options.MapFrom(src => src.Enfermedad.Nombre))
                .ForMember(dst => dst.EnfermedadRiesgo, options => options.MapFrom(src => src.Enfermedad.Riesgo))
                .ReverseMap();
            CreateMap<PacienteEnfermedad, PacienteEnfermedadPostDTO>()
                .ReverseMap();
            CreateMap<PacienteEnfermedadDTO, PacienteEnfermedadMiniDTO>()
                .ReverseMap();

        }

    }
}
