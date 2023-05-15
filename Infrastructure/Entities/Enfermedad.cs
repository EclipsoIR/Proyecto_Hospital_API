using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Entities
{

    public class Enfermedad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        public string Nombre { get; set; }  

        public int Riesgo { get; set; }

        //public int DiasTratamiento { get; set; }

        [AllowNull]
        public Guid? AreaId { get; set; }

        [ForeignKey("AreaId")]

        [DeleteBehavior(DeleteBehavior.NoAction)] //mirar

        public virtual Area Area { get; set; }

        public virtual ICollection<Tratamiento> Tratamientos { get; set; }

    }
}
