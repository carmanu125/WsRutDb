using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebServicesRutDb.Areas.api.Models
{
    public class CDropBox
    {

        public static DropboxClient dbxClient = new DropboxClient("7cvTGK43wbAAAAAAAAAAIKpEJzT2YMIdFa1RtpgmhIcLNjfRkgw6qlOoFoD19nbf");
        static string path = "/RutaDelBordado/";
        static string path_image_places = "places_image/";
        static string path_logo_places = "places_logo/";
        static string path_banner_places = "places/";
        public static int numPhoto;
        public static bool image;


        public static async Task<List<string>> ListFolderTree(List<string> list, int id)
        {
            try
            {
                string file = "";
                string directoryPath = path + path_image_places + id.ToString() + "/";

                //directoryPath += partner + "/" + unit + "/picture/" + clientId + "/";

                var listFolder = dbxClient.Files.ListFolderAsync(directoryPath).Result;

                // show folders then files

                foreach (var item in listFolder.Entries)
                {
                    file = item.Name;

                    //string file = path + partner + unit + clientId + (count <= 9 ? "0" + count : "" + count) + ".jpg";

                    var linkImage = dbxClient.Files.BeginGetTemporaryLink(directoryPath + file, null, null).AsyncWaitHandle;
                    var link = dbxClient.Files.GetTemporaryLinkAsync(directoryPath + file).Result;
                    //Asigno los valores a la clase 
                    //CDataFile dataFile = new CDataFile();

                    string imageUrl = link.Link;

                    //dataFile.Thumbnail = data;
                    list.Add(imageUrl);
                    //list.Add(dataFile);

                    numPhoto++;
                }

            }
            catch (Exception)
            {

            }

            return list;
        }

        public static async Task<string> ImageLogo(string value, int clientId)
        {
            numPhoto = 0;

            try
            {

                string directoryPath = path + path_logo_places + clientId;

                string file = directoryPath + ".png";

                var linkImage = dbxClient.Files.BeginGetTemporaryLink(file, null, null).AsyncWaitHandle;
                var link = dbxClient.Files.GetTemporaryLinkAsync(file).Result;

                string imageUrl = link.Link;

                //dataFile.Thumbnail = data;
                value = imageUrl;

            }
            catch (Exception)
            {
            }


            return value;
        }

        public static async Task<string> ImageBanner(string value, int clientId)
        {
            numPhoto = 0;

            try
            {

                string directoryPath = path + path_banner_places + clientId ;

                string file = directoryPath + "_banner.jpg";

                var linkImage = dbxClient.Files.BeginGetTemporaryLink(file, null, null).AsyncWaitHandle;
                var link = dbxClient.Files.GetTemporaryLinkAsync(file).Result;

                string imageUrl = link.Link;

                //dataFile.Thumbnail = data;
                value = imageUrl;

            }
            catch (Exception)
            {
            }


            return value;
        }

    }
}