using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using log4net;
using ProyectoPrueba.Mapper;
using ProyectoPrueba.ProyectoDbContext;
using ProyectoPrueba.Rules.IRules;
using ProyectoPrueba.Rules.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProyectoPrueba.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            var config = new MapperConfiguration(x => { x.AddProfile(new ProyectoPruebaProfile()); });
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterModule(new LoggingModule());

            builder.RegisterType<ProyectoPruebaDbContext>()
                .InstancePerRequest();

            builder.RegisterType<AlumnoRules>()
                .As<IAlumnoRules>()
                .InstancePerRequest();

            builder.RegisterType<CarreraRules>()
                .As<ICarreraRules>()
                .InstancePerRequest();

            builder.RegisterType<MateriaRules>()
                .As<IMateriaRules>()
                .InstancePerRequest();

            builder.RegisterType<InscripcionRules>()
                .As<IInscripcionRules>()
                .InstancePerRequest();

            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}