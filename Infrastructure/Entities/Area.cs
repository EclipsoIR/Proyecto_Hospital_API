using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public int Tamaño { get; set; }

        public Guid HospitalId { get; set; }

        [ForeignKey("HospitalId")]

        public virtual Hospital Hospital { get; set; }


        public virtual ICollection<Funcion> Funcions { get; set; }


        public virtual ICollection<Enfermedad> Enfermedades { get; set; }


    }
}
