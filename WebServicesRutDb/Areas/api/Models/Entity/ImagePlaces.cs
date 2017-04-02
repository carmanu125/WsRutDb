using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Areas.api.Models.Entity
{
    public class ImagePlaces
    {

        public int id { get; set; }
        public string url { get; set; }
        public int id_Place { get; set; }
    }
}