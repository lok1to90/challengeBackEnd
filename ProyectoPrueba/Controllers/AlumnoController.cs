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

    /// <summary>
    /// Contiene todos los metodos para manejo de alumnos.
    /// </summary>
    [RoutePrefix("alumno")]
    public class AlumnoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IAlumnoRules _alumnoRules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="alumnoRules"></param>
        public AlumnoController(IMapper mapper, IAlumnoRules alumnoRules)
        {
            _mapper = mapper;
            _alumnoRules = alumnoRules;
        }

        /// <summary>
        /// Obtiene todos los alumnos.
        /// </summary>
        /// <returns>Lista de todos los alumnos</returns>
        [ResponseType(typeof(IEnumerable<AlumnoModel>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var alumnos = _alumnoRules.GetAll(); ;
                if (alumnos.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<AlumnoModel>>(alumnos));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);   
            }
          
        }

        /// <summary>
        /// Obtiene un alumno por ID
        /// </summary>
        /// <param name="id">Id del Alumno.</param>
        /// <returns>Un Alumno</returns>
        [ResponseType(typeof(AlumnoModel))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var alumno = _alumnoRules.GetById(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<AlumnoModel>(alumno));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        /// <summary>
        /// Guarda un alumno
        /// </summary>
        /// <returns>Alumno Guardado</returns>
        [ResponseType(typeof(AlumnoModel))]
        [HttpPost]
        public IHttpActionResult Post(AlumnoModel alumno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _alumnoRules.Insert(_mapper.Map<Alumno>(alumno));
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }  
            
        }

        /// <summary>
        /// Actualiza un alumno
        /// </summary>
        /// <returns>Alumno actualizado</returns>
        [ResponseType(typeof(AlumnoModel))]
        [HttpPut]
        // PUT: api/Alumno/5
        public IHttpActionResult Put(AlumnoModel alumno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _alumnoRules.Update(_mapper.Map<Alumno>(alumno));
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Elimina un alumno por ID
        /// </summary>
        /// <param name="id">Id del Alumno.</param>
        [HttpDelete]
        // DELETE: api/Alumno/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                _alumnoRules.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
