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
    public class FuncionService
    {

        private AppDbContext db;

        public FuncionService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Funcion> GetByIdAsync(Guid id)
        {
            return await db.Funcion.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<List<Funcion>> GetListAsync()
        {
            return await db.Funcion.Include(x=>x.Area).ToListAsync();
        }

        public async Task<Funcion> DeleteAsync(Guid id)
        {
            var funcionOld = await GetByIdAsync(id);
            db.Remove(funcionOld);
            db.SaveChanges();
            return funcionOld;
        }


        public async Task<Funcion> AddEditAsync(Funcion funcion)
        {
            if (await GetByIdAsync(funcion.Id) != null)
            {
                return await EditAsync(funcion);
            }
            return await AddAsync(funcion);
        }

        public async Task<Funcion> AddAsync(Funcion funcion)
        {
            await db.AddAsync(funcion);
            db.SaveChanges();
            return funcion;
        }

        public async Task<Funcion> EditAsync(Funcion funcion)
        {
            Funcion funcionOld = await GetByIdAsync(funcion.Id);
            funcionOld.Nombre = funcion.Nombre;
            funcionOld.AreaId= funcion.AreaId;
            db.SaveChanges();
            return funcionOld;
        }


    }
}
