using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts
{
    public class Cheap
    {
            
        public class CreatedAt
        {
            public int id { get; set; }

        }

        public class Result
        {
            public int id { get; set; }
            public int cheap_id { get; set; }
            public List<CreatedAt> created_at { get; set; }
            public bool Active { get; set; }
            public DateTime created_date { get; set; }
            public List<Card.Result> cards  { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }










    }
}
