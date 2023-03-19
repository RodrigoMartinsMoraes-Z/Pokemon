using Pokemon.Context;
using Pokemon.Interfaces;
using Pokemon.Repository.Masters;
using Pokemon.Repository.Pokemons;

using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            var container = new Container();
            string connectionString = ConfigurationManager.ConnectionStrings["PokemonDb"].ConnectionString;

            // register the context
            container.Register<PokemonDbContext>(Lifestyle.Scoped);

            // register the factory
            container.Register<IDbContextFactory<PokemonDbContext>, PokemonDbContextFactory>(Lifestyle.Singleton);

            // register interfaces
            container.Register<ICapturedPokemonsRepository, CapturedPokemonsRepository>(Lifestyle.Scoped);
            container.Register<IMasterRepository, MasterRepository>(Lifestyle.Scoped);
            container.Register<IPokemonRepository, PokemonRepository>(Lifestyle.Scoped);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
