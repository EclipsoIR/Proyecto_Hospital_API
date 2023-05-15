using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.EnfermedadDTOs
{
    public class EnfermedadPostDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public int Riesgo { get; set; }

        public int DiasTratamiento { get; set; }

        public Guid AreaId { get; set; }
    }
}
