using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.HackerNewsClient.Models
{
    public class NewsModel
    {
        public List<News> NewsList { get; set; }

        public int CurrentPage { get; set; }

        public bool IsNextPageAvailable { get; set; }

        public int NextPage { get; set; }

        public bool IsPrevPageAvailable { get; set; }

        public int PrevPage { get; set; }
    }
}
