using Infrastructure.DTO.EnfermedadDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.HospitalDTOs
{
    public class HospitalEnfermedadMiniDTO
    {
        public HospitalMiniDTO Hospital { get; set; }

        public EnfermedadMiniDTO Enfermedad { get; set; }
    }
}
