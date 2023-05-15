using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Enums;

using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTO.MedicoDTOs
{
    public class MedicoPostDTO
    {
        public Guid Id { get; set; }



        public int Hora { get; set; }

        public int Minuto { get; set; }

        public int Segundo { get; set; }


        public Guid PersonaId { get; set; }

        public Guid HospitalId { get; set; }
        public Guid FuncionId { get; set; }

    }
}
