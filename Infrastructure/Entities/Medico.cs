using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Entities
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //public string Area { get; set; }
        public Guid FuncionId { get; set; }

        public TimeSpan HorasDia { get; set; }

        public Guid PersonaId { get; set; }

        public Guid HospitalId { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Persona Persona { get; set; }

        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }

        [ForeignKey("FuncionId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]        
        public virtual Funcion Funcion { get; set; }

        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }

    }
}
