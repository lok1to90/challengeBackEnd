using ProyectoPrueba.Domain;
using ProyectoPrueba.IRules;
using ProyectoPrueba.ProyectoDbContext;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Rules.Rules
{
    public class AlumnoRules : GenericRules<Alumno>, IAlumnoRules
    {
        public AlumnoRules(ProyectoPruebaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
