using Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MedicoService
    {
        private AppDbContext db;

        public MedicoService (AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Medico?> GetByIdAsync(Guid id)
        {
            //var result =  db.Medico.Where(x => x.Id == id).Include(x => x.Persona).Include(x=>x.Hospital);
            return await db.Medico.Where(x => x.Id == id).Include(x => x.Persona).Include(x => x.Hospital).FirstOrDefaultAsync();
        }



        public async Task<List<Medico>> GetListAsync()
        {
            return await db.Medico.Include(x => x.Persona).Include(x => x.Hospital).Include(x=>x.Funcion).ToListAsync();
        }

        public async Task<Medico> DeleteAsync(Guid id)
        {
            var MedicoOld = await GetByIdAsync(id);
            db.Remove(MedicoOld);
            db.SaveChanges();
            return MedicoOld;
        }


        public async Task<Medico> AddEditAsync(Medico medico)
        {
            if (await GetByIdAsync(medico.Id) != null)
            {
                return await EditAsync(medico);
            }
            return await AddAsync(medico);
        }

        public async Task<Medico> AddAsync(Medico medico)
        {

           await db.Medico.AddAsync(medico);
            db.SaveChanges();

            return medico;
        }

        public async Task<string> CheckCapacity(Medico medico)
        {

            var hospital = await db.Hospital.Where(x => x.Id == medico.HospitalId).FirstOrDefaultAsync();
            var medicoOld = await GetByIdAsync(medico.Id);
            int countDoctors = await db.Medico.Where(x => x.HospitalId == medico.HospitalId).CountAsync();
            if (hospital.CantTrabajadores > countDoctors)// ESta es la funcion que no se si esta muy bien para que si el hospital del nuevo medico es el mismo que el enterior te deje pasar
            {

                return string.Empty;
            }
            else if (medicoOld != null)
            {
                if(medico.HospitalId==medicoOld.HospitalId)
                {
                    return string.Empty;
                }
            }
            return $"El Hospital {hospital.Nombre} no tiene más capacidada para contrarar más medicos";

        }


        public async Task<string>CheckCapacityArea(Medico medico)
        {
            //var funcion = await db.Funcion.Where(x => x.Id == medico.FuncionId).Include(x => x.Area).FirstOrDefaultAsync();

            //int countDoctorsArea = await db.Medico.Where(x=>x.FuncionId == fun)

            var resolucion = (from m in db.Medico
                             join f in db.Funcion on m.FuncionId equals f.Id
                             join a in db.Area on f.AreaId equals a.Id
                             where f.AreaId == a.Id
                             select medico).ToList();
            var medicoOld = await GetByIdAsync(medico.Id);
            var funcion = await db.Funcion.Where(x => x.Id == medico.FuncionId).Include(x => x.Area).FirstOrDefaultAsync();

            if (funcion.Area.Tamaño > resolucion.Count()) // ESta es la funcion que no se si esta muy bien para que si el area del nuevo medico es la misma que la enterior te deje pasar
            {
                return string.Empty;
            }
            else if (medicoOld != null)
            {
                if (medicoOld.FuncionId == medico.FuncionId)
                {
                    return string.Empty;
                }
            }
            return "El area esta repleta de medicos";
        }








        public async Task<Medico> EditAsync(Medico medico)
        {
            Medico medicoOld = await GetByIdAsync(medico.Id);
            medicoOld.FuncionId = medico.FuncionId;
            medicoOld.HorasDia = medico.HorasDia;
            medicoOld.PersonaId= medico.PersonaId;
            medico.HospitalId = medico.HospitalId;
            db.SaveChanges();
            return medicoOld;
        }


        public async Task<List<Medico>> ShowDoctorsPatient()
        {
            var doctors = from p in db.Persona
                             join m in db.Medico on p.Id equals m.PersonaId
                             join pa in db.Paciente on p.Id equals pa.PersonaId
                             where m.PersonaId == pa.PersonaId
                             select m;

            return  doctors.Include(x=>x.Persona).Include(x=>x.Hospital).ToList();
        }

 






    }
}
