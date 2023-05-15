using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Tratamiento
    {

        public Guid Id { get; set; }

        public int Dias { get; set; }

        public Guid EnfermedadId { get; set; }

        [ForeignKey("EnfermedadId")]

        public virtual Enfermedad Enfermedad { get; set; }
    }
}
