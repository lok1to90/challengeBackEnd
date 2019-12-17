using AutoMapper;
using ProyectoPrueba.Domain;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoPrueba.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IAlumnoRules _alumnoRules;

        public AlumnoController(IMapper mapper, IAlumnoRules alumnoRules)
        {
            _mapper = mapper;
            _alumnoRules = alumnoRules;
        }
        // GET: api/Alumno
        //public IEnumerable<Alumno> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Alumno/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Alumno
        public IHttpActionResult Insert(Alumno alumno)
        {
            _alumnoRules.Insert(alumno);
            return Ok();
        }

        // PUT: api/Alumno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Alumno/5
        public void Delete(int id)
        {
        }
    }
}
