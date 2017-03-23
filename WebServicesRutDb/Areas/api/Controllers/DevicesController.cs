using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServicesRutDb.Areas.api.Models.Entity;
using WebServicesRutDb.Models;

namespace WebServicesRutDb.Areas.api.Controllers
{
    public class DevicesController : Controller
    {

        private DataBase dataBase;

        public DevicesController()
        {
            dataBase = new DataBase();
        }


        //
        // GET: /api/Devices/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult discountInMarker(Devices device)
        {

            string sql = "SELECT Id FROM Devices where Imei =  '" + device.imei + "'";

            int result = dataBase.ConsultInt(sql);

            if (result > 0)
            {
                return Json("Error");
            }
            else
            {
                string query = "INSERT INTO [dbo].[Devices] " + Environment.NewLine +
                               "([Imei]" + Environment.NewLine +
                               ",[Device]" + Environment.NewLine +
                               ",[Hardware]" + Environment.NewLine +
                               ",[Brand]" + Environment.NewLine +
                               ",[Model]" + Environment.NewLine +
                               ",[Serial]" + Environment.NewLine +
                               ",[User_phone]" + Environment.NewLine +
                               ",[Version_sdk])" + Environment.NewLine +
                         "VALUES" + Environment.NewLine +
                               "('" + device.imei + "'," + Environment.NewLine +
                               "'" + device.device + "'," + Environment.NewLine +
                               "'" + device.hardware + "'," + Environment.NewLine +
                               "'" + device.brand + "'," + Environment.NewLine +
                               "'" + device.model + "'," + Environment.NewLine +
                               "'" + device.serial + "'," + Environment.NewLine +
                               "'" + device.user + "'," + Environment.NewLine +
                               "'" + device.versionSdk + "')";

                int rows = dataBase.ExecuteSQL(query);

                return Json(Convert.ToString((rows > 0)));

            }

        }

    }
}
