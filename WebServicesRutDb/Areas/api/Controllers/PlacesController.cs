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


        // GET: /api/Places/Clientes/
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
                    place.name = rw[0].ToString();
                    place.short_description = rw[0].ToString();
                    place.description = rw[0].ToString();
                    place.address = rw[0].ToString();
                    place.phone = rw[0].ToString();
                    place.email = rw[0].ToString();
                    place.latLong = rw[0].ToString();
                    place.Ranking = rw[0].ToString();

                    lista.Add(place);

                }
            }

            
 


            return Json(lista,
                        JsonRequestBehavior.AllowGet);
        }
    }
}
