using AutoMapper;
using Data;
using Infrastructure.DTO.PersonaDTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PersonaService
    {
        private AppDbContext db;
        private IMapper mapper;

        public PersonaService(AppDbContext db, IMapper _mapper)
        {
            this.db = db;
            this.mapper = _mapper;
        }


        public async Task<Persona> GetByIdAsync(Guid id)
        {
            return await db.Persona.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<List<Persona>> GetListAsync()
        {
            return await db.Persona.ToListAsync();
        }

        public async Task<List<PersonaMiniDTO>> GetListAsyncForPage()
        {
            var resultado =  await db.Persona.ToListAsync();
            var reusltadoMAp = mapper.Map<List<PersonaMiniDTO>>(resultado);
            return reusltadoMAp;
        }




        public async Task<Persona> DeleteAsync(Guid id)
        {
            var personaOld = await GetByIdAsync(id);
            db.Remove(personaOld);
            db.SaveChanges();
            return personaOld;
        }


        public async Task<DataTableDTO> GetPersonListPerPage(int page)
        {
            var max = 6 * page;
            var min = max - 6;

            var personList = await GetListAsyncForPage();

            
            int totalPages = (int) Math.Truncate(Convert.ToDecimal(personList.Count()/6))+1;

            if (page == totalPages)
            {
                max = personList.Count();

            }

            return new DataTableDTO(page, totalPages, personaMiniDTOs(min, max, personList));

        }

        private List<PersonaMiniDTO> personaMiniDTOs(int min, int max, List<PersonaMiniDTO> data)
        {
            var result = new List<PersonaMiniDTO>();
            for (int i = min; i < max; i++)
            {
                    result.Add(data[i]);
            }
            return result;
        }


        public async Task<Persona> AddEditAsync(Persona persona)
        {
            if (await GetByIdAsync(persona.Id) != null)
            {
                return await EditAsync(persona);
            }
            return await AddAsync(persona);
        }

        public async Task<Persona> AddAsync(Persona persona)
        {
            await db.AddAsync(persona);
            db.SaveChanges();
            return persona;
        }

        public async Task<Persona> EditAsync(Persona persona)
        {
            Persona personaOld = await GetByIdAsync(persona.Id);
            personaOld.Nombre= persona.Nombre;
            personaOld.P_Apellido=persona.P_Apellido;
            personaOld.S_Apellido= persona.S_Apellido;
            personaOld.Edad = persona.Edad;
            personaOld.Estado = persona.Estado;
            db.SaveChanges();
            return personaOld;
        }


    }
}
