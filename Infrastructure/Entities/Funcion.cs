using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities
{
    public class Funcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Guid AreaId { get; set; }

        [ForeignKey("AreaId")]

        public virtual Area Area { get; set; }
    }
}
