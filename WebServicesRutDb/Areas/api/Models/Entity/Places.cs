using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Models.Entity
{
    public class Places
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_description { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string latLong { get; set; }
        public string Ranking { get; set; }
        public string Url_image { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string Url_logo { get; set; }

    }
}