using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Enums;

using System.Threading.Tasks;

namespace Infrastructure.DTO.HospitalDTOs
{
    public class HospitalPostDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Localizacion Localizacion { get; set; }

        public string Especialidades { get; set; }

        public int Capacidad { get; set; }

        public int CantTrabajadores { get; set; }
    }
}
