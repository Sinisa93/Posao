using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
namespace Luka.Controllers
{
    public class JsonToObject
    {
        public static object Convert(String filePath)
        {
            string jsonString = loadJsonFileToString(filePath);
            return convertToObject(jsonString);
        }

        private static string loadJsonFileToString(String filePath)
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + "Controllers\\JSON\\" + filePath;
            StreamReader reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }
        
        private static object convertToObject(String json)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            return j.Deserialize(json, typeof(object));
        }
            
    }
}