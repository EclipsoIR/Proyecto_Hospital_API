using Infrastructure.DTO.AreaDTOs;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.FuncionDTO
{
    public class FuncionMiniDTO
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Guid AreaId { get; set; }

        //public AreaDTO Area { get; set; }


        public string AreaNombre { get; set; }

        public int AreaTamaño { get; set; }

        public Guid AreaHospitalId { get; set; }

        //public string HospitalNombre { get; set; }

        //public Localizacion HospitalLocalizacion { get; set; }

        //public string HospitalEspecialidades { get; set; }

        //public int HospitalCapacidad { get; set; }

        //public int HospitalCantTrabajadores { get; set; }



    }
}
