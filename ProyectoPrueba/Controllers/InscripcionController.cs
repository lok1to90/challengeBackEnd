using AutoMapper;
using ProyectoPrueba.Rules.IRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoPrueba.Controllers
{
    public class InscripcionController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IInscripcionRules _inscripcionRules;

        public InscripcionController(IMapper mapper, IInscripcionRules inscripcionRules)
        {
            _mapper = mapper;
            _inscripcionRules = inscripcionRules;
        }
        // GET: api/Inscripcion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Inscripcion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inscripcion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Inscripcion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inscripcion/5
        public void Delete(int id)
        {
        }
    }
}
