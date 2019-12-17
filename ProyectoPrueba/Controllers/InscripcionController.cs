using AutoMapper;
using ProyectoPrueba.Domain;
using ProyectoPrueba.Model;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProyectoPrueba.Controllers
{
    [RoutePrefix("inscripcion")]
    public class InscripcionController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IInscripcionRules _inscripcionRules;

        public InscripcionController(IMapper mapper, IInscripcionRules inscripcionRules)
        {
            _mapper = mapper;
            _inscripcionRules = inscripcionRules;
        }

        /// <summary>
        /// Obtiene todas las materias en donde se anoto
        /// </summary>
        /// <returns>Inscripciones</returns>
        [HttpGet]
        [Route("alumno/{idAlumno}")]
        public IHttpActionResult GetAllByAlumno(int idAlumno)
        {
            try
            {
                return Ok(_mapper.Map<List<InscripcionModel>>(_inscripcionRules.GetAllByAlumno(idAlumno)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var inscripcion = _inscripcionRules.GetById(id);
                if (inscripcion == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<InscripcionModel>(inscripcion));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Guarda una inscripcion a un alumno
        /// </summary>
        /// <returns>Inscripcion guardada</returns>
        [ResponseType(typeof(InscripcionModel))]
        [HttpPost]
        [Route("alumno/{idAlumno}")]
        public IHttpActionResult Post(InscripcionModel inscripcion, int idAlumno)
        {
            try
            {
                if (!ModelState.IsValid || inscripcion == null)
                    return BadRequest();

                _inscripcionRules.Insert(_mapper.Map<Inscripcion>(inscripcion), idAlumno);
                return Ok(inscripcion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Finalizar el cursado de una materia
        /// </summary>
        [HttpPost]
        public IHttpActionResult PostFinalizarCursado(int idInscripcion, int nota)
        {
            try
            {
                _inscripcionRules.Insert(_mapper.Map<Inscripcion>(idInscripcion), nota);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
