using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.DTO.PacienteEnfermedadDTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PacienteEnfermedadService
    {
        private AppDbContext db;

        public PacienteEnfermedadService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<PacienteEnfermedad> GetByIdAsync(Guid id)
        {
            return await db.PacienteEnfermedads.Where(x => x.Id == id).Include(x => x.Paciente).Include(x=>x.Enfermedad).FirstOrDefaultAsync();
        }

        public async Task<List<PacienteEnfermedad>> GetListAsync()
        {
            return await db.PacienteEnfermedads.Include(x => x.Paciente).Include(x => x.Enfermedad).ToListAsync();
        }


        public async Task<PacienteEnfermedad> DeleteAsync(Guid id)
        {
            var PacienteEnfermedadOld = await GetByIdAsync(id);
            db.Remove(PacienteEnfermedadOld);
            db.SaveChanges();
            return PacienteEnfermedadOld;
        }


        public async Task<PacienteEnfermedad> AddEditAsync(PacienteEnfermedad pacienteEnfermedad)
        {
            if (await GetByIdAsync(pacienteEnfermedad.Id) != null)
            {
                return await EditAsync(pacienteEnfermedad);
            }
            return await AddAsync(pacienteEnfermedad);
        }


        public async Task<PacienteEnfermedad> AddAsync(PacienteEnfermedad pacienteEnfermedad)
        {

            await db.AddAsync(pacienteEnfermedad);
            db.SaveChanges();
            return pacienteEnfermedad;

        }


        public async Task<PacienteEnfermedad> EditAsync(PacienteEnfermedad pacienteEnfermedad)
        {
            var pacienteEnfermedadOld = await GetByIdAsync(pacienteEnfermedad.Id);
            pacienteEnfermedadOld.Fecha = pacienteEnfermedad.Fecha;
            pacienteEnfermedadOld.PacienteId= pacienteEnfermedad.PacienteId;
            pacienteEnfermedadOld.EnfermedadId= pacienteEnfermedad.EnfermedadId;
            db.SaveChanges();
            return pacienteEnfermedad;

        }


        public async Task<List<Paciente>> GetPacienteEnfermedadByDates(DateTime? startDate, DateTime? endDate)
        {
            var paciente = from pe in db.PacienteEnfermedads
                       join p in db.Paciente on pe.PacienteId equals p.Id
                       where (pe.Fecha> startDate) & (pe.Fecha<endDate)
                       select p;

            var pacientes = paciente.ToList();

            return pacientes;

        }

        public async Task<(Enfermedad enf,HospitalMiniDTO hsp)> GetHospitalWithMostPatient()
        {
            var hospital = from paEn in db.PacienteEnfermedads
                           join p in db.Paciente on paEn.PacienteId equals p.Id
                           join h in db.Hospital on p.HospitalId equals h.Id

                           select new HospitalMiniDTO
                           {
                               Id = h.Id,
                               Nombre = h.Nombre,
                               Localizacion = h.Localizacion,
                               Especialidades = h.Especialidades,
                               Capacidad = h.Capacidad,
                               CantTrabajadores = h.CantTrabajadores,
                               TrabajadoresActuales = db.Medico.Where(x=>x.HospitalId==h.Id).Count(),
                               PacientesActuales = db.Paciente.Where(x => x.HospitalId == h.Id).Count()
                           };

            var resultadolistHo = await hospital.ToListAsync();
            int idautoincremnetHo = 0;
            int idresultadoHo = 0;
            int maxcountpacientesHo = 0;
            foreach (var item in resultadolistHo)
            {
                if (item.PacientesActuales > maxcountpacientesHo)
                {
                    maxcountpacientesHo = item.PacientesActuales;
                    idresultadoHo = idautoincremnetHo;
                }
                ++idautoincremnetHo;

            }
            var hospitalMaxPAtient = resultadolistHo[idautoincremnetHo-1];


            var resultado = from paEn in db.PacienteEnfermedads
                            join p in db.Paciente on paEn.PacienteId equals p.Id
                            join h in db.Hospital on p.HospitalId equals h.Id
                            where  p.HospitalId == hospitalMaxPAtient.Id 
                            select new PacienteEnfermedadMiniDTO
                            {
                                Id = paEn.Id,
                                Fecha = paEn.Fecha,
                                PacienteId = paEn.PacienteId,
                                EnfermedadId = paEn.EnfermedadId,
                                EnfermedadNombre = paEn.Enfermedad.Nombre,
                                EnfermedadRiesgo = paEn.Enfermedad.Riesgo,
                                //EnfermedadCountPacientes = db.Enfermedad.Where(x => x.Id == paEn.EnfermedadId).Count(),
                            };
            var resultadolist = await resultado.ToListAsync();
            var resultadoAgrupado = resultadolist.GroupBy(x => x.EnfermedadId).ToList();

            var a = resultadoAgrupado.Where(x => x.Count() == resultadoAgrupado.Max(x => x.Count())).FirstOrDefault().Key;


            var pacienteEnfermedad = await new  EnfermedadService(db).GetByIdAsync(a);

            return (pacienteEnfermedad, hospitalMaxPAtient);

        }





    }
}
