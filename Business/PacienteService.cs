using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PacienteService
    {
        private AppDbContext db;

        public PacienteService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Paciente?> GetByIdAsync(Guid id)
        {
            return await db.Paciente.Where(x => x.Id == id).Include(x=>x.Persona).Include(x=>x.Hospital).FirstOrDefaultAsync();
        }



        public async Task<List<Paciente>> GetListAsync()
        {
            return await db.Paciente.Include(x=>x.Persona).Include(x => x.Hospital).ToListAsync();
        }

        public async Task<Paciente> DeleteAsync(Guid id)
        {
            var pacienteOld = await GetByIdAsync(id);
            db.Remove(pacienteOld);
            db.SaveChanges();
            return pacienteOld;
        }


        public async Task<Paciente> AddEditAsync(Paciente paciente)
        {
            if (await GetByIdAsync(paciente.Id) != null)
            {
                return await EditAsync(paciente);
            }
            return await AddAsync(paciente);
        }

        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            
            await db.AddAsync(paciente);
            db.SaveChanges();
            return paciente;
        }

        public async Task<string> CheckCapacity (Paciente paciente)
        {

            var hospital = await db.Hospital.Where(x => x.Id == paciente.HospitalId).FirstOrDefaultAsync();
            int countPacientes = await db.Paciente.Where(x => x.HospitalId == paciente.HospitalId).CountAsync();
            if (hospital.Capacidad > countPacientes|| await GetByIdAsync(paciente.Id)!=null)
            {
                return string.Empty;

            }
            return $"El Hospital {hospital.Nombre} no tiene más capacidada para pacientes";

        }

        public async Task<Paciente> EditAsync(Paciente paciente)
        {
            Paciente pacienteOld = await GetByIdAsync(paciente.Id);
            pacienteOld.Fecha = paciente.Fecha;
            pacienteOld.Motivo = paciente.Motivo;
            db.SaveChanges();
            return pacienteOld;
        }

        public async Task<Paciente> GetRandomPatient(Guid idDoctor)
        {
            var pacientes = (from h in db.Hospital
                            join m in db.Medico on h.Id equals m.HospitalId
                            join p in db.Paciente on h.Id equals p.HospitalId
                            where m.Id == idDoctor
                            select p).Include(x=>x.Persona).Include(x=>x.Hospital).ToList();
            Random r = new Random();
            var paciente =  pacientes[r.Next(pacientes.Count()-1)];
            return paciente;
        }






    }
}
