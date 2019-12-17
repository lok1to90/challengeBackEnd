using AutoMapper;
using ProyectoPrueba.Domain;
using ProyectoPrueba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Mapper
{
    public class ProyectoPruebaProfile : Profile
    {
        public ProyectoPruebaProfile()
        {
            CreateMap<Alumno, AlumnoModel>().ReverseMap();
            CreateMap<Carrera, CarreraModel>().ReverseMap();
            CreateMap<Inscripcion, InscripcionModel>().ReverseMap();
            CreateMap<Materia, MateriaModel>().ReverseMap();
        }
    }
}