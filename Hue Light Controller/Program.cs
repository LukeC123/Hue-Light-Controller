using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace Hue_Light_Controller
{
    class Program
    {
        // args[0]: on, off, increase, decrease
        // args[1]: --, ---, (percentage), (percentage)
        static void Main(string[] args)
        {

            if (args[0] == "on")
            {
                var data = @"{""on"":true}";
                putRequest(data);
                return;
            }

            if (args[0] == "off")
            {
                var data = @"{""on"":false}";
                putRequest(data);
                return;
            }

            if (args[0] == "increase")
            {
                double percentage = double.Parse(args[1]) / 100;
                double oldPercentage = getBrightnessPercentage();
                
                double newPercentage = percentage + oldPercentage;

                if (newPercentage > 1.0)
                    newPercentage = 1.0;

                newPercentage = 254 * newPercentage;

                var data = @"{""bri"":" + (int)newPercentage + "}";

                putRequest(data);

                return;
            }

            if (args[0] == "decrease")
            {
                double percentage = double.Parse(args[1]) / 100;
                double oldPercentage = getBrightnessPercentage();

                double newPercentage = oldPercentage - percentage;

                if (newPercentage < 0.0)
                    newPercentage = 0.0;

                newPercentage = 254 * newPercentage;

                var data = @"{""bri"":" + (int)newPercentage + "}";

                putRequest(data);

                return;
            }
        }

        public static void putRequest(string data)
        {

            string url = "http://192.168.1.184/api/4ta4berm0CgEzPY2l-EpxdwUCcHs8rOBZVmtim8C/groups/4/action/";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "PUT";

            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static double getBrightnessPercentage()
        {

            string url = "http://192.168.1.184/api/4ta4berm0CgEzPY2l-EpxdwUCcHs8rOBZVmtim8C/groups/4/";

            string json = new WebClient().DownloadString(url);
            JObject jsonObject = JObject.Parse(json);

            JToken state = jsonObject.SelectToken("action").SelectToken("bri");

            return Math.Round((double)(int)state / 254, 2);
        }

    }
}
