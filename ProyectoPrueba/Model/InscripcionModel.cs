using ProyectoPrueba.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Model
{
    public class InscripcionModel
    {
        public int Id { get; set; }
        [Required]
        public int MateriaId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public CursadoEstadoEnum Estado { get; set; }
        public int Nota { get; set; }
    }
}