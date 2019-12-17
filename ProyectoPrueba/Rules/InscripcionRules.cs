using log4net;
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
        private readonly ProyectoPruebaDbContext _dbContext;
        private readonly ILog _logger;

        public InscripcionRules(ProyectoPruebaDbContext dbContext, ILog logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void FinalizarCursado(int idInscripcion, int nota)
        {
            try
            {
                var inscripcion = _dbContext.Inscripciones.Find(idInscripcion);
                inscripcion.Estado = Enums.CursadoEstadoEnum.FINALIZADO;
                inscripcion.Nota = nota;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public IList<Inscripcion> GetAllByAlumno(int idAlumno)
        {
            try
            {
                var alumno = _dbContext.Alumnos.Find(idAlumno);
                if(alumno != null)
                {
                    return alumno.Inscripciones;
                }
                else
                {
                    throw new Exception("No existe alumno");
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Insert(Inscripcion inscripcion, int idAlumno)
        {
            try
            {
                var alumno = _dbContext.Alumnos.Find(idAlumno);
                alumno.Inscripciones.Add(inscripcion);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
    }
}
