using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Area> Area { get; set; }

        public DbSet<Funcion> Funcion { get; set; }

        public DbSet<Enfermedad> Enfermedad { get; set; }

        public DbSet<PacienteEnfermedad> PacienteEnfermedads { get; set; }

        public DbSet<Diagnostico> Diagnostico { get; set; }

        public DbSet<Tratamiento> Tratamiento { get; set; }

        public DbSet<TratamientoDiagnostico> TratamientoDiagnosticos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().ToTable("Hospital");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Funcion>().ToTable("Funcion");
            modelBuilder.Entity<Enfermedad>().ToTable("Enfermedad");
            modelBuilder.Entity<PacienteEnfermedad>().ToTable("PacienteEnfermedad");
            modelBuilder.Entity<Diagnostico>().ToTable("Diagnostico");
            modelBuilder.Entity<Tratamiento>().ToTable("Tratamiento");
            modelBuilder.Entity<TratamientoDiagnostico>().ToTable("TratamientoDiagnostico");

        }





    }

}

