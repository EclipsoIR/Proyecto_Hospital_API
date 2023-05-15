using AutoMapper;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.MedicoDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfileArea : Profile
    {
        public MapperProfileArea()
        {
            CreateMap<Area, AreaDTO>()
                                //.ForMember(dst => dst.Hospital, options => options.MapFrom(src => src.Hospital))
                .ForMember(dst => dst.HospitalNombre, options => options.MapFrom(src => src.Hospital.Nombre))
                .ForMember(dst => dst.HospitalLocalizacion, options => options.MapFrom(src => src.Hospital.Localizacion))
                .ForMember(dst => dst.HospitalEspecialidades, options => options.MapFrom(src => src.Hospital.Especialidades))
                .ForMember(dst => dst.HospitalCapacidad, options => options.MapFrom(src => src.Hospital.Capacidad))
                .ForMember(dst => dst.HospitalCantTrabajadores, options => options.MapFrom(src => src.Hospital.CantTrabajadores))
                .ForMember(dst => dst.Funcions, options => options.MapFrom(src => src.Funcions))
                .ReverseMap();
            CreateMap<Area, AreaMiniDTO>()
                                //.ForMember(dst => dst.Hospital, options => options.MapFrom(src => src.Hospital))
                .ForMember(dst => dst.HospitalNombre, options => options.MapFrom(src => src.Hospital.Nombre))
                .ForMember(dst => dst.HospitalLocalizacion, options => options.MapFrom(src => src.Hospital.Localizacion))
                .ForMember(dst => dst.HospitalEspecialidades, options => options.MapFrom(src => src.Hospital.Especialidades))
                .ForMember(dst => dst.HospitalCapacidad, options => options.MapFrom(src => src.Hospital.Capacidad))
                .ForMember(dst => dst.HospitalCantTrabajadores, options => options.MapFrom(src => src.Hospital.CantTrabajadores))
                .ForMember(dst => dst.Funcions, options => options.MapFrom(src => src.Funcions))
                .ReverseMap();

            CreateMap<Area, AreaPostDTO>()
                 .ReverseMap();

            CreateMap<AreaDTO, AreaMiniDTO>()
                .ReverseMap();

        }

    }
}
