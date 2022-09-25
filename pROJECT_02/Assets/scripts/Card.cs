using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts
{
    public class Card
    {

        public class ContentFile
        {
            public string url { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public int card_id { get; set; }
            public string content_type { get; set; }
            public bool Active { get; set; }
            public string content_text { get; set; }
            public List<ContentFile> content_file { get; set; }
            public DateTime created_date { get; set; }
            public object accessed_date { get; set; }
            public double? easy_factor { get; set; }
            public object new_access_date { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }



    }
}
