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
    public class MateriaController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMateriaRules _materiaRules;

        public MateriaController(IMapper mapper, IMateriaRules materiaRules)
        {
            _mapper = mapper;
            _materiaRules = materiaRules;
        }
        // GET: api/Materia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Materia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Materia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Materia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Materia/5
        public void Delete(int id)
        {
        }
    }
}
