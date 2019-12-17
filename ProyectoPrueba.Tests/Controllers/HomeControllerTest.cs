using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPrueba;
using ProyectoPrueba.Controllers;
using ProyectoPrueba.Domain;
using ProyectoPrueba.Model;

namespace ProyectoPrueba.Tests.Controllers
{
    [TestClass]
    public class AlumnoControllerTest
    {
        private List<Alumno> GetTestAlumnos()
        {
            var testAlumnos = new List<Alumno>();
            testAlumnos.Add(new Alumno { Id = 1, Nombre = "Guillermo" });
            testAlumnos.Add(new Alumno { Id = 2, Nombre = "Lucia"});
            testAlumnos.Add(new Alumno { Id = 3, Nombre = "Pablo"});

            return testAlumnos;
        }

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
