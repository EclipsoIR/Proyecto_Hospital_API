using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Enums;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HospitalService
    {
        private AppDbContext db;

        public HospitalService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Hospital> GetByIdAsync(Guid id)
        {
            return await db.Hospital.Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<List<Hospital>> GetListAsync()
        {
            return await db.Hospital.ToListAsync();
        }

        public async Task<Hospital> DeleteAsync (Guid id)
        {
            var hospitalOld = await GetByIdAsync(id);
            db.Remove(hospitalOld);
            db.SaveChanges();
            return hospitalOld;
        }


        public async Task<Hospital> AddEditAsync(Hospital hospital)
        {
            if (await GetByIdAsync(hospital.Id)!=null) 
            {
                return await EditAsync(hospital);
            }
            return await AddAsync(hospital);
        }

        public async Task<Hospital> AddAsync (Hospital hospital)
        {
            await db.AddAsync(hospital);
            db.SaveChanges();
            return hospital;
        }

        public async Task<Hospital> EditAsync (Hospital hospital)
        {
            Hospital hospitalOld = await GetByIdAsync(hospital.Id);
            hospitalOld.Nombre = hospital.Nombre;
            hospitalOld.CantTrabajadores = hospital.CantTrabajadores;
            hospitalOld.Especialidades = hospital.Especialidades;
            hospitalOld.Capacidad = hospital.Capacidad;
            hospitalOld.Especialidades = hospital.Especialidades;
            hospitalOld.Localizacion = hospital.Localizacion;
            db.SaveChanges();
            return hospitalOld;
        }

        public async Task<List<HospitalMiniDTO>> GetPacientesMedicosActuales()
        {
            var resultado = from h in db.Hospital
                            //join m in db.Medico on h.Id equals m.HospitalId
                            //join p in db.Paciente on h.Id equals p.HospitalId
                            select new HospitalMiniDTO
                            {
                                
                                Id = h.Id,
                                Nombre = h.Nombre,
                                Capacidad = h.Capacidad,
                                CantTrabajadores = h.CantTrabajadores,
                                Especialidades = h.Especialidades,
                                Localizacion = h.Localizacion,
                                TrabajadoresActuales = db.Medico.Where(x => x.HospitalId == h.Id).Count(),
                                PacientesActuales = db.Paciente.Where(x => x.HospitalId == h.Id).Count()
                            };
            return resultado.ToList();
        }

        public async Task<List<Hospital>> GetHospitalByReason(MotivoPaciente motivo)
        {
            var hospitales = from h in db.Hospital
                             join p in db.Paciente on h.Id equals p.HospitalId
                             where p.Motivo == motivo
                             select h;
            return hospitales.ToList();
        }




    }
}
