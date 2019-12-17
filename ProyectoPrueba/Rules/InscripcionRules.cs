using ProyectoPrueba.Domain;
using ProyectoPrueba.ProyectoDbContext;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Rules.Rules
{
    public class InscripcionRules : GenericRules<Inscripcion>, IInscripcionRules
    {
        public InscripcionRules(ProyectoPruebaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
