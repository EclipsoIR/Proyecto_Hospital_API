using Infrastructure.DTO.FuncionDTO;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.AreaDTOs
{
    public class AreaMiniDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public int Tamaño { get; set; }

        public Guid HospitalId { get; set; }

        //public HospitalDTO Hospital { get; set; }


        public string HospitalNombre { get; set; }

        public Localizacion HospitalLocalizacion { get; set; }

        public string HospitalEspecialidades { get; set; }

        public int HospitalCapacidad { get; set; }

        public int HospitalCantTrabajadores { get; set; }

        public List<FuncionMiniDTO> Funcions { get; set; }


    }
}
