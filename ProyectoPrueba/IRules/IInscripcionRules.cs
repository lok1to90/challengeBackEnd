using ProyectoPrueba.Domain;
using ProyectoPrueba.IRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPrueba.Rules.IRules
{
    public interface IInscripcionRules : IGenericRules<Inscripcion>
    {
        void Insert(Inscripcion inscripcion, int idAlumno);
        void FinalizarCursado(int idInscripcion, int nota);
    }
}
