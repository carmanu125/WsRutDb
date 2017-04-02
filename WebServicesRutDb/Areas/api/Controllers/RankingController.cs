using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServicesRutDb.Areas.api.Models.Entity;
using WebServicesRutDb.Models;

namespace WebServicesRutDb.Areas.api.Controllers
{
    public class RankingController : Controller
    {

        private DataBase dataBase;

        public RankingController()
        {
            dataBase = new DataBase();
        }

        //
        // GET: /api/Ranking/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RankingPlace(Ranking ranking)
        {
            string sql = "SELECT Id FROM Devices WHERE Imei = '" + ranking.id_Imei + "';";
            ranking.id_Device = dataBase.ConsultInt(sql);
            sql = "SELECT Id FROM Ranking WHERE Id_Place = " + ranking.id_Place + " and Id_Device = " + ranking.id_Device + ";";
            bool hasRanking = false;

            int result = dataBase.ConsultInt(sql);
            ranking.id_Ranking= result;

            if (result > 0)
            {
                string query = "UPDATE Ranking SET value = " + ranking.value + " WHERE ID = " + ranking.id_Ranking + ";";
                int rows = dataBase.ExecuteSQL(query);
                hasRanking = true;
            }
            else
            {
                string query = "INSERT INTO Ranking (Id_Place, Id_Device, [value]) VALUES (" + ranking.id_Place + ", " + ranking.id_Device + ", " + ranking.value + ");";

                int rows = dataBase.ExecuteSQL(query);

                hasRanking = true;
            }

            string query2 = "UPDATE Places set Ranking = (SELECT AVG(value) AS RankingAverage FROM Ranking WHERE Id_Place = " + ranking.id_Place + ") where id = " + ranking.id_Place + ";";

            int updateResult = dataBase.ExecuteSQL(query2);

            return Json(hasRanking.ToString());
        }


    }
}
