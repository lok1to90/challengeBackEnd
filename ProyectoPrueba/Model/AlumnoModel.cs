using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Model
{
    public class AlumnoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public virtual CarreraModel Carrera { get; set; }
    }
}