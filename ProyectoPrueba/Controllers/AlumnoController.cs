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

namespace ProyectoPrueba.Controllers
{
    [RoutePrefix("Alumno")]
    public class AlumnoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IAlumnoRules _alumnoRules;

        public AlumnoController(IMapper mapper, IAlumnoRules alumnoRules)
        {
            _mapper = mapper;
            _alumnoRules = alumnoRules;
        }
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            var alumnos = _alumnoRules.GetAll(); ;

            if (alumnos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(alumnos);
        }

        [HttpGet]
        // GET: api/Alumno/5
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Alumno alumno = _alumnoRules.GetById(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPost]
        // POST: api/Alumno
        public IHttpActionResult Post(AlumnoModel alumno)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                _alumnoRules.Insert(_mapper.Map<Alumno>(alumno));
                return Ok(alumno);
            }
            catch (Exception)
            {
                return InternalServerError();
            }  
            
        }

        [HttpPut]
        // PUT: api/Alumno/5
        public IHttpActionResult Put(AlumnoModel alumno)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            _alumnoRules.Update(_mapper.Map<Alumno>(alumno));
            return Ok(alumno);
        }

        [HttpDelete]
        // DELETE: api/Alumno/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            _alumnoRules.Delete(id);
            return Ok();

        }
    }
}
