using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Model
{
    public class CarreraModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TituloOtorgado { get; set; }
        public virtual IList<MateriaModel> Materias { get; set; }
    }
}