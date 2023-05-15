using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Enums;

using System.Threading.Tasks;

namespace Infrastructure.DTO.PacienteDTOs
{
    public class PacientePostDTO
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public MotivoPaciente Motivo { get; set; }

        public Guid PersonaId { get; set; }

        public Guid HospitalId { get; set; }
    }
}
