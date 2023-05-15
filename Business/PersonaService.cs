using Data;
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

        public PersonaService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Persona> GetByIdAsync(Guid id)
        {
            return await db.Persona.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<List<Persona>> GetListAsync()
        {
            return await db.Persona.ToListAsync();
        }

        public async Task<Persona> DeleteAsync(Guid id)
        {
            var personaOld = await GetByIdAsync(id);
            db.Remove(personaOld);
            db.SaveChanges();
            return personaOld;
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
