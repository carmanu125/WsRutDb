﻿using System.Web.Mvc;

namespace WebServicesRutDb.Areas.api
{
    public class apiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "api_default",
                "api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Clientes",
                "api/Places/Clientes/",
                new { action = "Clientes", id = UrlParameter.Optional }
            );
        }
    }
}
