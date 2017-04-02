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
        public JsonResult discountInMarker(int? id, Devices device)
        {

            string sql = "SELECT Id FROM Devices where Imei =  '" + device.imei + "'";
            bool hasDiscount = false;

            int result = dataBase.ConsultInt(sql);
            device.id_Device = result;

            if (result > 0)
            {
                //return Json("Error");
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

                string sqlID = "SELECT Id FROM Devices where Imei =  '" + device.imei + "'";
                int resultID = dataBase.ConsultInt(sqlID);
                device.id_Device = resultID;

                //bool wasInserted = (rows > 0);


            }

            hasDiscount = checkDiscount(device, id.GetValueOrDefault());

            return Json(hasDiscount.ToString());


        }

        private bool checkDiscount(Devices device, int idPlace){

            string sql = "SELECT ID,Id_Place,Id_Device FROM Discount_Places WHERE Id_Place = " + idPlace + " AND Id_Device = " + device.id_Device;
            
            int idDiscount = dataBase.ConsultInt(sql);

            // No existen registros para ese local
            if (!(idDiscount > 0))
            {

                string query = "INSERT INTO Discount_Places (Id_Place,Id_Device) values (" + idPlace + "," + device.id_Device + ")";

                int rows = dataBase.ExecuteSQL(query);

                return true;
            }
           
            // ya se reclamo el descuento
            return false;

        }

    }
}
