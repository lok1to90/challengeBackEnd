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
    public class CarreraController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICarreraRules _carreraRules;

        public CarreraController(IMapper mapper, ICarreraRules carreraRules)
        {
            _mapper = mapper;
            _carreraRules = carreraRules;
        }
        // GET: api/Carrera
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Carrera/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Carrera
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Carrera/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Carrera/5
        public void Delete(int id)
        {
        }
    }
}
