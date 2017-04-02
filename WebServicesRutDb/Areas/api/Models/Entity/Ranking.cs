using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Areas.api.Models.Entity
{
    public class Ranking
    {
        public int id_Ranking { get; set; }
        public int id_Place { get; set; }
        public int id_Device { get; set; }
        public string id_Imei { get; set; }
        public string value { get; set; }
    }
}