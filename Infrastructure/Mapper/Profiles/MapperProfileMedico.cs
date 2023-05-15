using AutoMapper;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfileMedico : Profile
    {
        public MapperProfileMedico()
        {
            CreateMap<Medico, MedicoDTO>()
                .ForMember(dst  =>    dst.PersonaNombre, options => options.MapFrom(src => src.Persona.Nombre))
                .ForMember(dst  =>    dst.PersonaP_Apellido, options => options.MapFrom(src => src.Persona.P_Apellido))
                .ForMember(dst => dst.PersonaS_Apellido, options => options.MapFrom(src => src.Persona.S_Apellido))
                .ForMember(dst => dst.PersonaEdad, options => options.MapFrom(src => src.Persona.Edad))
                .ForMember(dst => dst.PersonaEstado, options => options.MapFrom(src => src.Persona.Estado))
                .ForMember(dst => dst.HospitalNombre, options => options.MapFrom(src => src.Hospital.Nombre))
                .ForMember(dst => dst.HospitalLocalizacion, options => options.MapFrom(src => src.Hospital.Localizacion))
                .ForMember(dst => dst.HospitalEspecialidades, options => options.MapFrom(src => src.Hospital.Especialidades))
                .ForMember(dst => dst.HospitalCapacidad, options => options.MapFrom(src => src.Hospital.Capacidad))
                .ForMember(dst => dst.HospitalCantTrabajadores, options => options.MapFrom(src => src.Hospital.CantTrabajadores))
                .ForMember(dst => dst.FuncionNombre, options => options.MapFrom(src => src.Funcion.Nombre))
                .ForMember(dst => dst.AreaId, options => options.MapFrom(src => src.Funcion.AreaId))

                .ReverseMap();
            CreateMap<Medico, MedicoMiniDTO>()
                .ForMember(dst => dst.PersonaNombre, options => options.MapFrom(src => src.Persona.Nombre))
                .ForMember(dst => dst.PersonaP_Apellido, options => options.MapFrom(src => src.Persona.P_Apellido))
                .ForMember(dst => dst.PersonaS_Apellido, options => options.MapFrom(src => src.Persona.S_Apellido))
                .ForMember(dst => dst.PersonaEdad, options => options.MapFrom(src => src.Persona.Edad))
                .ForMember(dst => dst.PersonaEstado, options => options.MapFrom(src => src.Persona.Estado))
                .ForMember(dst => dst.HospitalNombre, options => options.MapFrom(src => src.Hospital.Nombre))
                .ForMember(dst => dst.HospitalLocalizacion, options => options.MapFrom(src => src.Hospital.Localizacion))
                .ForMember(dst => dst.HospitalEspecialidades, options => options.MapFrom(src => src.Hospital.Especialidades))
                .ForMember(dst => dst.HospitalCapacidad, options => options.MapFrom(src => src.Hospital.Capacidad))
                .ForMember(dst => dst.HospitalCantTrabajadores, options => options.MapFrom(src => src.Hospital.CantTrabajadores))
                .ForMember(dst => dst.FuncionNombre, options => options.MapFrom(src => src.Funcion.Nombre))
                .ForMember(dst => dst.AreaId, options => options.MapFrom(src => src.Funcion.AreaId))


                .ReverseMap();
            CreateMap<Medico, MedicoPostDTO>();
            CreateMap<MedicoPostDTO, Medico>()
                .ForMember(dst=>dst.HorasDia, options=> options.MapFrom(src=> new TimeSpan(src.Hora,src.Minuto,src.Segundo)));
                
            CreateMap<MedicoDTO, MedicoMiniDTO>()
                .ReverseMap();
        }
    }
}
