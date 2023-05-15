using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.DiagnosticoDTOs
{
    public class DiagnosticoPostDTO
    {

        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public Guid MedicoId { get; set; }

        public Guid PacienteId { get; set; }

    }
}
