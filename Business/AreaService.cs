using Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;


namespace Business
{
    public class AreaService
    {
        private AppDbContext db;

        public AreaService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Area> GetByIdAsync(Guid id)
        {
            return await db.Area.Where(x => x.Id == id).Include(x => x.Hospital).Include(x=>x.Funcions).FirstOrDefaultAsync();
        }



        public async Task<List<Area>> GetListAsync()
        {
            return await db.Area.Include(x=>x.Hospital).Include(x => x.Funcions).ToListAsync();
        }

        public async Task<Area> DeleteAsync(Guid id)
        {

            var enfermedades = await db.Enfermedad.Where(x => x.AreaId == id).ToListAsync();
            foreach (var item in enfermedades)
            {
                item.AreaId = null;
            }
            db.SaveChanges();

            var arealOld = await GetByIdAsync(id);
            db.Remove(arealOld);
            db.SaveChanges();
            return arealOld;
        }


        public async Task<Area> AddEditAsync(Area area)
        {
            if (await GetByIdAsync(area.Id) != null)
            {
                return await EditAsync(area);
            }
            return await AddAsync(area);
        }

        public async Task<Area> AddAsync(Area area)
        {
            await db.AddAsync(area);
            db.SaveChanges();
            return area;
        }

        public async Task<Area> EditAsync(Area area)
        {
            Area areaOld = await GetByIdAsync(area.Id);
            areaOld.Nombre = area.Nombre;
            areaOld.Tamaño = area.Tamaño;
            areaOld.HospitalId = area.HospitalId;
            db.SaveChanges();
            return areaOld;
        }

        public async Task<Area> TakeAreaForDoctar(Guid id)
        {
            var medico = await new MedicoService(db).GetByIdAsync(id);
            var area = from f in db.Funcion
                       join m in db.Medico on f.Id equals m.FuncionId
                       join a in db.Area on f.AreaId equals a.Id
                       where f.Id == medico.FuncionId
                       select a;

            return await area.FirstOrDefaultAsync();


        }




        public async Task<List<Area>> GetAreasFunctionsHospitalPatient(Paciente paciente)
        {
            var areas = db.Area.Where(x => x.HospitalId == paciente.HospitalId).Include(x => x.Funcions).ToList();

            return areas;
        }



    }
}
