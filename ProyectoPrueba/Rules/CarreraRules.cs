using log4net;
using ProyectoPrueba.Domain;
using ProyectoPrueba.ProyectoDbContext;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Rules.Rules
{
    public class CarreraRules : GenericRules<Carrera>, ICarreraRules
    {
        public CarreraRules(ProyectoPruebaDbContext dbContext, ILog logger) : base(dbContext, logger)
        {

        }
    }
}
