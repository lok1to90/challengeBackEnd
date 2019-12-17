using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Domain
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual IList<Inscripcion> Inscripciones { get; set; }
    }
}