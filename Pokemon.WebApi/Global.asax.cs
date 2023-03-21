using AutoMapper;

using Pokemon.AutoMapper;
using Pokemon.Context;
using Pokemon.Interfaces;
using Pokemon.Interfaces.Services;
using Pokemon.Repository.Masters;
using Pokemon.Repository.Pokemons;
using Pokemon.Service;

using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

using Swashbuckle.Application;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pokemon.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "My Poke API");
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            }).EnableSwaggerUi();

            // configuração do container simple injector

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //string connectionString = ConfigurationManager.ConnectionStrings["PokemonDb"].ConnectionString;

            // register the context
            container.Register<IContext, PokemonDbContext>(Lifestyle.Scoped);

            // register the factory
            container.Register<IDbContextFactory<PokemonDbContext>, PokemonDbContextFactory>(Lifestyle.Singleton);

            // register interfaces
            container.Register<ICapturedPokemonsRepository, CapturedPokemonsRepository>();
            container.Register<IMasterRepository, MasterRepository>();
            container.Register<IPokemonRepository, PokemonRepository>();

            container.Register<IMasterService, MasterService>();
            container.Register<IPokemonService, PokemonService>();

            // register Auto Mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MasterMappingProfile>();
                cfg.AddProfile<PokemonMappingProfile>();
            });

            container.RegisterInstance<MapperConfiguration>(mapperConfig);
            container.Register<IMapper>(() => mapperConfig.CreateMapper(container.GetInstance));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterInstance(GlobalConfiguration.Configuration);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
