using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.AreaDTOs
{
    public class AreaPostDTO
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public int Tamaño { get; set; }

        public Guid HospitalId { get; set; }
    }
}
