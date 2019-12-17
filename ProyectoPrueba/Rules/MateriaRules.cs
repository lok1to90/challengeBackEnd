using ProyectoPrueba.Domain;
using ProyectoPrueba.ProyectoDbContext;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Rules.Rules
{
    public class MateriaRules : GenericRules<Materia>, IMateriaRules
    {
        public MateriaRules(ProyectoPruebaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
