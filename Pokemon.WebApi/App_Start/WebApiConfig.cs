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

        }
    }
}
