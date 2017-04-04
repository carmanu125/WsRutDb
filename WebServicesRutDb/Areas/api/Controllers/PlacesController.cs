﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebServicesRutDb.Areas.api.Models;
using WebServicesRutDb.Areas.api.Models.Entity;
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
                    place.Url_image = getUrlImage(place.id);
                    place.facebook = rw[10].ToString();
                    place.instagram = rw[11].ToString();
                    place.twitter = rw[12].ToString();
                    place.Url_logo = getUrlLogo(place.id);

                    lista.Add(place);

                }
            }

            return Json(lista,
                        JsonRequestBehavior.AllowGet);
        }

        private string getUrlLogo(int id)
        {

            string value = "";
            Task<string> task = CDropBox.ImageBanner(value, id);
            task.Wait();
            value = task.Result;

            return value;
        }

        private string getUrlImage(int id)
        {
            string value = "";
            Task<string> task = CDropBox.ImageLogo(value, id);
            task.Wait();
            value = task.Result;

            return value;
        }

        // GET: /api/Places/ImagesPlaces/
        /*[HttpGet]
        public JsonResult ImagesPlaces(int? id)
        {

            List<ImagePlaces> lista = new List<ImagePlaces>();

            string sql = "SELECT Id,Url,Id_Place FROM Places_Image WHERE Id_Place = " + id.GetValueOrDefault();

            DataTable dt = dataBase.ConsultSQL(sql);

            if (dt.Columns.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    ImagePlaces image = new ImagePlaces();

                    image.id = Convert.ToInt32(rw[0].ToString());
                    image.url = rw[1].ToString();
                    image.id_Place = Convert.ToInt32(rw[2].ToString());

                    lista.Add(image);
                }
            }

            return Json(lista,
                        JsonRequestBehavior.AllowGet);
        }*/

        [HttpGet]
        public JsonResult ImagesPlaces(int? id)
        {

            List<ImagePlaces> lista = new List<ImagePlaces>();

            List<string> listImage = new List<string>();

            Task<List<string>> task = CDropBox.ListFolderTree(listImage, id.GetValueOrDefault());
            task.Wait();


             foreach (string value in listImage)
                {
                    ImagePlaces image = new ImagePlaces();

                    //image.id = Convert.ToInt32(rw[0].ToString());
                    image.url = value;
                    //image.id_Place = Convert.ToInt32(rw[2].ToString());

                    lista.Add(image);
                }
            

            return Json(lista,
                        JsonRequestBehavior.AllowGet);
        }

    }
}
