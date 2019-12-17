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
    /// Contiene todos los metodos para manejo de materia.
    /// </summary>
    [RoutePrefix("materia")]
    public class MateriaController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMateriaRules _materiaRules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="materiaRules"></param>
        public MateriaController(IMapper mapper, IMateriaRules materiaRules)
        {
            _mapper = mapper;
            _materiaRules = materiaRules;
        }

        /// <summary>
        /// Obtiene todos las materias.
        /// </summary>
        /// <returns>Lista de todos las materias</returns>
        [ResponseType(typeof(IEnumerable<MateriaModel>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var materias = _materiaRules.GetAll(); ;
                if (materias.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<MateriaModel>>(materias));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Obtiene una materia por ID
        /// </summary>
        /// <param name="id">Id de materia.</param>
        /// <returns>Una materia</returns>
        [ResponseType(typeof(MateriaModel))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var materia = _materiaRules.GetById(id);
                if (materia == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<MateriaModel>(materia));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Guarda una materia
        /// </summary>
        /// <returns>Materia guardada</returns>
        [ResponseType(typeof(MateriaModel))]
        [HttpPost]
        public IHttpActionResult Post(MateriaModel materia)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _materiaRules.Insert(_mapper.Map<Materia>(materia));
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Actualiza una materia
        /// </summary>
        /// <returns>Materia actualizada</returns>
        [ResponseType(typeof(MateriaModel))]
        [HttpPut]
        public IHttpActionResult Put(MateriaModel materia)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _materiaRules.Update(_mapper.Map<Materia>(materia));
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        
        /// <summary>
        /// Elimina una materia por ID
        /// </summary>
        /// <param name="id">Id de materia.</param>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                _materiaRules.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
