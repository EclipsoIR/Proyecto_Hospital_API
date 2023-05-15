using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.DiagnosticoDTOs
{
    public class DiagnosticoMiniDTO
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public Guid MedicoId { get; set; }

        public Guid PacienteId { get; set; }

        public string PacienteNombre { get; set; }

        public string PacienteApellido { get; set; }

        //public List<string> PacienteEnfermedades { get; set; }

        public string MedicoNombre { get; set; }

        public string MedicoApellido { get; set; }

        public string MedicoFuncionNombre { get; set; }



    }
}
