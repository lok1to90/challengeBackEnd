using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Domain
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TituloOtorgado { get; set; }
        public virtual IList<Materia> Materias { get; set; }
    }
}
