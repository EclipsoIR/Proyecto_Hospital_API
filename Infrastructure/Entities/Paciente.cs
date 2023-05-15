using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Enums;
using System.Data;

namespace Infrastructure.Entities
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public MotivoPaciente Motivo { get; set; }

        public Guid PersonaId { get; set; }

        [ForeignKey("PersonaId")]

        public virtual Persona Persona { get; set; }

        public Guid HospitalId { get; set; }

        [ForeignKey("HospitalId")]

        public virtual Hospital Hospital { get; set; }


        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }

        public virtual ICollection<PacienteEnfermedad> PacienteEnfermedads { get; set; }
    }

}
