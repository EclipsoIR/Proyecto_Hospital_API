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
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Localizacion Localizacion { get; set; }

        public string Especialidades { get; set; }

        public int Capacidad { get; set; }

        public int CantTrabajadores { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
