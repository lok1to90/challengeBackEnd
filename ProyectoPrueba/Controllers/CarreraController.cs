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
    /// Contiene todos los metodos para manejo de carreras.
    /// </summary>
    [RoutePrefix("carrera")]
    public class CarreraController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICarreraRules _carreraRules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="carreraRules"></param>
        public CarreraController(IMapper mapper, ICarreraRules carreraRules)
        {
            _mapper = mapper;
            _carreraRules = carreraRules;
        }

        /// <summary>
        /// Obtiene todos las carreras.
        /// </summary>
        /// <returns>Lista de todos las carreras</returns>
        [ResponseType(typeof(IEnumerable<CarreraModel>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var carreras = _carreraRules.GetAll(); ;
                if (carreras.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<CarreraModel>>(carreras));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Obtiene una carrera por ID
        /// </summary>
        /// <param name="id">Id de carrera.</param>
        /// <returns>Una carrera</returns>
        [ResponseType(typeof(CarreraModel))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var carrera = _carreraRules.GetById(id);
                if (carrera == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<CarreraModel>(carrera));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Guarda una carrera
        /// </summary>
        /// <returns>Carrera guardada</returns>
        [ResponseType(typeof(CarreraModel))]
        [HttpPost]
        public IHttpActionResult Post(CarreraModel carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _carreraRules.Insert(_mapper.Map<Carrera>(carrera));
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Actualiza una carrera
        /// </summary>
        /// <returns>Carrera actualizada</returns>
        [ResponseType(typeof(CarreraModel))]
        [HttpPut]
        public IHttpActionResult Put(CarreraModel carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _carreraRules.Update(_mapper.Map<Carrera>(carrera));
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Elimina una carrera por ID
        /// </summary>
        /// <param name="id">Id de carrera.</param>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                _carreraRules.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
