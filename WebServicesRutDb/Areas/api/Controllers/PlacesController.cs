using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServicesRutDb.Models;
using WebServicesRutDb.Models.Entity;

namespace WebServicesRutDb.Areas.api.Controllers
{
    public class PlacesController : Controller
    {

        private DataBase dataBase;

        public PlacesController()
        {
            dataBase = new DataBase();
        }

        //
        // GET: /api/Places/

        public ActionResult Index()
        {
            return View();
        }


        // GET: /api/Places/Places/
        [HttpGet]
        public JsonResult Places()
        {

            List<Places> lista = new List<Places>();

           

            string sql = "SELECT * FROM Places";

            DataTable dt = dataBase.ConsultSQL(sql);

            if (dt.Columns.Count > 0)
            {
                foreach(DataRow rw in dt.Rows){

                    Places place = new Places();

                    place.id = Convert.ToInt32(rw[0].ToString());
                    place.name = rw[1].ToString();
                    place.short_description = rw[2].ToString();
                    place.description = rw[3].ToString();
                    place.address = rw[4].ToString();
                    place.phone = rw[5].ToString();
                    place.email = rw[6].ToString();
                    place.latLong = rw[7].ToString();
                    place.Ranking = rw[8].ToString();
                    place.Url_image = rw[9].ToString();

                    lista.Add(place);

                }
            }

            return Json(lista,
                        JsonRequestBehavior.AllowGet);
        }

    }
}
