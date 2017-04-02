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
                "Places",
                "api/Places/Places/",
                new { action = "Places", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "discountInMarker",
                "api/Devices/discountInMarker/{id}",
                new
                {
                    controller = "Devices",
                    action = "discountInMarker",
                    id = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "ImagesPlaces",
                "api/Places/ImagesPlaces/{id}",
                new
                {
                    controller = "Places",
                    action = "ImagesPlaces",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
