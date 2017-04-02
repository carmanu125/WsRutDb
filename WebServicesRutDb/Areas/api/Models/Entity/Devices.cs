using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Areas.api.Models.Entity
{
    public class Devices
    {
        public int id_Device { get; set; }
        public string imei { get; set; }
        public string brand{ get ; set ; }
        public string device{ get ; set ; }
        public string hardware{ get ; set ; }
        public string model{ get ; set ; }
        public string serial{ get ; set ; }
        public string user{ get ; set ; }
        public string versionSdk{ get ; set ; }
    }
}