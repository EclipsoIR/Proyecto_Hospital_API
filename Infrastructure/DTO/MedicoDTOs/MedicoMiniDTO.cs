using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Enums;

using System.Threading.Tasks;

namespace Infrastructure.DTO.MedicoDTOs
{
    public class MedicoMiniDTO
    {
        public Guid Id { get; set; }

        public TimeSpan HorasDia { get; set; }

        public Guid PersonaId { get; set; }

        public string PersonaNombre { get; set; }

        public string PersonaP_Apellido { get; set; }

        public string PersonaS_Apellido { get; set; }

        public int PersonaEdad { get; set; }

        public EstadosPersonasType PersonaEstado { get; set; }


        public Guid HospitalId { get; set; }


        public string HospitalNombre { get; set; }

        public Localizacion HospitalLocalizacion { get; set; }

        public string HospitalEspecialidades { get; set; }

        public int HospitalCapacidad { get; set; }

        public int HospitalCantTrabajadores { get; set; }

        public Guid FuncionId { get; set; }

        public string FuncionNombre { get; set; }

        public Guid AreaId { get; set; }

    }
}
