using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.PacienteEnfermedadDTOs
{
    public class PacienteEnfermedadPostDTO
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public Guid PacienteId { get; set; }

        public Guid EnfermedadId { get; set; }

    }
}
