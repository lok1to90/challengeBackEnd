using ProyectoPrueba.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.ProyectoDbContext
{
    public class ProyectoPruebaDbContext : DbContext
    {
        public ProyectoPruebaDbContext() : base("name=DEFAULT_CX")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

    }
}