using AutoMapper;
using Infrastructure.DTO.AreaDTOs;
using Infrastructure.DTO.FuncionDTO;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfileFuncion: Profile
    {
        public MapperProfileFuncion()
        {
            CreateMap<Funcion, FuncionDTO>()
                //.ForMember(dst => dst.Hospital, options => options.MapFrom(src => src.Hospital))
                .ForMember(dst => dst.AreaNombre, options => options.MapFrom(src => src.Area.Nombre))
                .ForMember(dst => dst.AreaTamaño, options => options.MapFrom(src => src.Area.Tamaño))
                .ForMember(dst => dst.AreaHospitalId, options => options.MapFrom(src => src.Area.HospitalId))

                .ReverseMap();
            CreateMap<Funcion, FuncionMiniDTO>()
                  //.ForMember(dst => dst.Hospital, options => options.MapFrom(src => src.Hospital))
                .ForMember(dst => dst.AreaNombre, options => options.MapFrom(src => src.Area.Nombre))
                .ForMember(dst => dst.AreaTamaño, options => options.MapFrom(src => src.Area.Tamaño))
                .ForMember(dst => dst.AreaHospitalId, options => options.MapFrom(src => src.Area.HospitalId))

                .ReverseMap();
            CreateMap<Funcion, FuncionPostDTO>()
                 .ReverseMap();
            CreateMap<FuncionDTO, FuncionMiniDTO>()
                .ReverseMap();
        }
    }
}
