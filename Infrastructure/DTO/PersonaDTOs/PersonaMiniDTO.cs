using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Enums;

using System.Threading.Tasks;

namespace Infrastructure.DTO.PersonaDTOs
{
    public class PersonaMiniDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string P_Apellido { get; set; }

        public string S_Apellido { get; set; }

        public int Edad { get; set; }

        public EstadosPersonasType Estado { get; set; }
    }
}
