using AutoMapper;
using Pokemon.Context;
using Pokemon.Interfaces;
using Pokemon.Repository.Masters;
using Pokemon.Repository.Pokemons;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using SimpleInjector;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Pokemon.AutoMapper;
using Pokemon.Interfaces.Services;
using Pokemon.Service;

namespace Pokemon.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // configuração do container simple injector

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterMvcControllers();
            container.RegisterWebApiControllers(config);
            container.RegisterInstance(config);

            string connectionString = ConfigurationManager.ConnectionStrings["PokemonDb"].ConnectionString;

            // register the context
            container.Register<IContext, PokemonDbContext>(Lifestyle.Scoped);

            // register the factory
            container.Register<IDbContextFactory<PokemonDbContext>, PokemonDbContextFactory>(Lifestyle.Singleton);

            // register interfaces
            container.Register<ICapturedPokemonsRepository, CapturedPokemonsRepository>();
            container.Register<IMasterRepository, MasterRepository>();
            container.Register<IPokemonRepository, PokemonRepository>();

            container.Register<IMasterService, MasterService>();

            // register Auto Mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MasterMappingProfile>();
                cfg.AddProfile<PokemonMappingProfile>();
            });

            container.RegisterInstance<MapperConfiguration>(mapperConfig);
            container.Register<IMapper>(() => mapperConfig.CreateMapper(container.GetInstance));

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
}
}
