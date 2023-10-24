using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace field_tracker_api.Models.Pet
{
    public class Field_PassObject
    {
        public Int64 user_id { get; set; }
        public String title { get; set; }
        public String vegetation { get; set; }
        public String square { get; set; }
        public String humidity { get; set; }
        public String status { get; set; }
        public DateTime date { get; set; }
    }
}
