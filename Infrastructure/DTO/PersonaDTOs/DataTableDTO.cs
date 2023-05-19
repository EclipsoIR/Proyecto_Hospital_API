using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.PersonaDTOs
{
    public class DataTableDTO
    {
        public  int Page { get; set; }

        public int TotalPages { get; set; }

        public  List<PersonaMiniDTO> Result { get; set; }

        public DataTableDTO(int _page, int _totalPages, List<PersonaMiniDTO> _resultado) { Page = _page; TotalPages = _totalPages; Result = _resultado; }
    }

}
