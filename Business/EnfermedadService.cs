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
    public class EnfermedadService
    {
        private AppDbContext db;

        public EnfermedadService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Enfermedad> GetByIdAsync(Guid id)
        {
            return await db.Enfermedad.Where(x => x.Id == id).Include(x => x.Area).FirstOrDefaultAsync();
        }

        public async Task<List<Enfermedad>> GetListAsync()
        {
            return await db.Enfermedad.Include(x => x.Area).Include(x => x.Area.Hospital).ToListAsync();
        }


        public async Task<Enfermedad> DeleteAsync(Guid id)
        {


            var enfermedadOld = await GetByIdAsync(id);
            db.Remove(enfermedadOld);
            db.SaveChanges();
            return enfermedadOld;
        }


        public async Task<Enfermedad> AddEditAsync(Enfermedad enfermedad)
        {
            if (await GetByIdAsync(enfermedad.Id) != null)
            {
                return await EditAsync(enfermedad);
            }
            return await AddAsync(enfermedad);
        }


        public async Task<Enfermedad> AddAsync (Enfermedad enfermedad)
        {

            await db.AddAsync(enfermedad);
            db.SaveChanges();
            return enfermedad;

        }


        public async Task<Enfermedad> EditAsync (Enfermedad enfermedad)
        {
            var enfermedadOld = await GetByIdAsync(enfermedad.Id);
            enfermedadOld.Nombre= enfermedad.Nombre;
            enfermedadOld.Riesgo = enfermedad.Riesgo;
            enfermedadOld.AreaId = enfermedad.AreaId;
            db.SaveChanges();
            return enfermedad;

        }







    }
}
