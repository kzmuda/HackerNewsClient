using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Codecool.HackerNewsClient.Models
{
    public class News
    {
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [JsonProperty("Time_ago")]
        public string TimeAgo { get; set; }

        public string User { get; set; }

        public string Url { get; set; }
    }
}
