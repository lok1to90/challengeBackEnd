using ProyectoPrueba.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Model
{
    public class InscripcionModel
    {
        public int Id { get; set; }
        public MateriaModel Materia { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public CursadoEstadoEnum Estado { get; set; }
        public int Nota { get; set; }
    }
}