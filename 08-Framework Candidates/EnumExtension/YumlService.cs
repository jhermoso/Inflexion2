namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Net;
    using System.Diagnostics;

    public static class YumlService
    {
        // Sample
        // StringBuilder dsl = new StringBuilder();
        // dsl.Append("[Cliente]-^[Player],");
        // dsl.Append("[Anunciante]-^[Cliente],");
        // dsl.Append("[Cliente]++->[Address]");
        // var yumlBytes = CreateYuml(dsl.ToString());

        public static byte[] CreateYuml(string dsl)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("dsl_text", dsl);

            string imageId = HttpPost("http://yuml.me/diagram/scruffy/class/", parameters);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://yuml.me/diagram/scruffy/class/" + imageId);
            request.Timeout = 10000000;
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        if (response != null) break;
                    }
                    catch
                    { }
                }

            }
            if (response == null) { Debug.WriteLine(string.Format(" Se ha producido una excepción con el servidor de yuml ")); }
            else
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    response.GetResponseStream().CopyTo(stream);
                    var yumlBytes = stream.ToArray();
                    return yumlBytes;
                }
            }
            return null;
        }

        public static void CreateYuml(string dsl, string yumlFilePath)
        {
            var yUmlBytes = CreateYuml(dsl);
            using (System.IO.FileStream file = System.IO.File.Create(yumlFilePath))
            {
                file.Write(yUmlBytes, 0, yUmlBytes.Length);
            }
        }

        private static string HttpPost(string uri, Dictionary<string, string> parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);
            req.Timeout = 1000000;
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.Timeout = 10000000;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(DictionaryToPostString(parameters));
            req.ContentLength = bytes.Length;

            using (System.IO.Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length); //Push it out there
            }
            System.Net.WebResponse resp = req.GetResponse();

            if (resp == null)
            {
                return null;
            }

            using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
            {
                return sr.ReadToEnd().Trim();
            }
        }

        private static string DictionaryToPostString(Dictionary<string, string> postVariables)
        {
            string postString = "";
            foreach (KeyValuePair<string, string> pair in postVariables)
            {
                postString += System.Web.HttpUtility.UrlEncode(pair.Key) + "=" +
                    HttpUtility.UrlEncode(pair.Value) + "&";
            }

            return postString;
        }
    }
}
