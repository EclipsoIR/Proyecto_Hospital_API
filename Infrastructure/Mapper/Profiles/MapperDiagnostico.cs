using AutoMapper;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.DiagnosticoDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperDiagnostico : Profile
    {
        public MapperDiagnostico() 
        {
            CreateMap<Diagnostico, DiagnosticoDTO>()
                .ForMember(dst => dst.PacienteNombre, options => options.MapFrom(src => src.Paciente.Persona.Nombre))
                .ForMember(dst => dst.PacienteApellido, options => options.MapFrom(src => src.Paciente.Persona.Nombre))
                .ForMember(dst => dst.MedicoNombre, options => options.MapFrom(src => src.Medico.Persona.Nombre))
                .ForMember(dst => dst.MedicoApellido, options => options.MapFrom(src => src.Medico.Persona.P_Apellido))
                .ForMember(dst => dst.MedicoFuncionNombre, options => options.MapFrom(src => src.Medico.Funcion.Nombre))
                .ReverseMap();
            CreateMap<Diagnostico, DiagnosticoMiniDTO>()
                 .ForMember(dst => dst.PacienteNombre, options => options.MapFrom(src => src.Paciente.Persona.Nombre))
                .ForMember(dst => dst.PacienteApellido, options => options.MapFrom(src => src.Paciente.Persona.Nombre))
                .ForMember(dst => dst.MedicoNombre, options => options.MapFrom(src => src.Medico.Persona.Nombre))
                .ForMember(dst => dst.MedicoApellido, options => options.MapFrom(src => src.Medico.Persona.P_Apellido))
                .ForMember(dst => dst.MedicoFuncionNombre, options => options.MapFrom(src => src.Medico.Funcion.Nombre))
                .ReverseMap();
            CreateMap<Diagnostico, DiagnosticoPostDTO>()
                .ReverseMap();
            CreateMap<DiagnosticoDTO, DiagnosticoMiniDTO>()
                .ReverseMap();

        }
    }
}
