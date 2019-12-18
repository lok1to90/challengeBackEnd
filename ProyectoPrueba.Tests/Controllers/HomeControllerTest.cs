using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoPrueba;
using ProyectoPrueba.Controllers;
using ProyectoPrueba.Domain;
using ProyectoPrueba.Model;
using ProyectoPrueba.Rules.IRules;

namespace ProyectoPrueba.Tests.Controllers
{
    [TestClass]
    public class AlumnoControllerTest
    {
        //public AlumnoControllerTest(IMapper _mapper, IAlumnoRules)
        //{

        //}
        //private List<Alumno> GetTestAlumnos()
        //{
        //    var testAlumnos = new List<Alumno>();
        //    testAlumnos.Add(new Alumno { Id = 1, Nombre = "Guillermo" });
        //    testAlumnos.Add(new Alumno { Id = 2, Nombre = "Lucia"});
        //    testAlumnos.Add(new Alumno { Id = 3, Nombre = "Pablo"});

        //    return testAlumnos;
        //}

        //[TestMethod]
        //public void GetByIdTest()
        //{
        //    var controller = new AlumnoController();

        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        [TestMethod]
        public void Index()
        {
            //// Arrange
            //AlumnoController controller = new AlumnoController();

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
