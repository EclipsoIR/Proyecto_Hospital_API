using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Diagnostico
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        [AllowNull]
        public Guid? MedicoId { get; set; }

        public Guid PacienteId { get; set; }

        [ForeignKey("MedicoId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]

        public virtual Medico Medico { get; set; }

        [ForeignKey("PacienteId")]


        public virtual Paciente Paciente { get; set; }

    }
}
