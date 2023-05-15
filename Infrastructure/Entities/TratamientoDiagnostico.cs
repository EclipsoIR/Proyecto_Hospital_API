using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class TratamientoDiagnostico
    {
        public Guid Id { get; set; }


        public Guid TratamientoId { get; set; }

        public Guid DiagnosticoId { get; set; }

        [ForeignKey("TratamientoId")]

        // CREO que aqui es ande hay que poner lo del tratamiento
        public virtual Tratamiento Tratamiento { get; set; }


        [ForeignKey("DiagnosticoId")]

        public virtual Diagnostico Diagnostico { get; set; }

    }
}
