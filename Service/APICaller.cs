using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Codecool.HackerNewsClient.Models;
using Newtonsoft.Json;

namespace Codecool.HackerNewsClient.Service
{
    public class APICaller
    {
        public static List<News> GetNews(int page)
        {
            return Read(page, "news");
        }

        public static List<News> GetJobs(int page)
        {
            return Read(page, "jobs");
        }

        public static List<News> GetNewest(int page)
        {
            return Read(page, "newest");
        }

        private static List<News> Read(int page, string section)
        {
            var url = $"https://api.hnpwa.com/v0/{section}/{page}.json";
            var jsonString = String.Empty;

            // var request = WebRequest.Create(url);
            // request.Method = "GET";
            // var response = request.GetResponse();
            //
            // 
            // using (Stream stream = response.GetResponseStream())
            // {
            //     var reader = new StreamReader(stream, Encoding.UTF8);
            //     jsonString = reader.ReadToEnd();
            // }

            using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
            {
                jsonString = wc.DownloadString(url);
            }

            return JsonConvert.DeserializeObject<List<News>>(jsonString);
        }
    }
}
