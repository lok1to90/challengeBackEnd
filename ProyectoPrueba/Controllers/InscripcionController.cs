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

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var inscripcions = _inscripcionRules.GetAll(); ;
                if (inscripcions.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<InscripcionModel>>(inscripcions));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        // GET: api/inscripcion/5
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

        [HttpPut]
        // PUT: api/inscripcion/5
        public IHttpActionResult Put(InscripcionModel inscripcion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _inscripcionRules.Update(_mapper.Map<Inscripcion>(inscripcion));
                return Ok(inscripcion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        // DELETE: api/inscripcion/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                _inscripcionRules.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
