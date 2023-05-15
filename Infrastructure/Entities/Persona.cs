using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string P_Apellido { get; set; }

        public string S_Apellido { get; set; }

        public int Edad { get; set; }

        public EstadosPersonasType Estado { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set;}

        public virtual ICollection<Medico> Medicos { get; set; }
    }

}
