using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoPrueba.Domain
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CargaHoraria { get; set; }
    }
}
