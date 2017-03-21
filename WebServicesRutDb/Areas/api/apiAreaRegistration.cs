using System.Web.Mvc;

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
<<<<<<< HEAD
                "api/Places/Places/",
=======
                "api/Places/",
>>>>>>> ae5b44ec6392dcdbc7fb754c52fc58dd68057e9f
                new { action = "Places", id = UrlParameter.Optional }
            );
        }
    }
}
