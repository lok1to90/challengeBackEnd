using ProyectoPrueba.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Domain
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public Materia Materia { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public CursadoEstadoEnum Estado { get; set; }
        public int Nota { get; set; }
    }
}
