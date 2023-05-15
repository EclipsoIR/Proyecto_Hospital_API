using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.TratamientoDTOs
{
    public class TratamientoPostDTO
    {
        public Guid Id { get; set; }

        public int Dias { get; set; }

        public Guid EnfermedadId { get; set; }
    }
}
