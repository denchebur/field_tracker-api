using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Services.Models
{
    public class Field_ResultSet
    {

        public Int64 field_id { get; set; }
        public Int64 user_id { get; set; }
        public String title { get; set; }
        public String vegetation { get; set; }
        public String square { get; set; }
        public String humidity { get; set; }
        public String status { get; set; }
        public DateTime date { get; set; }
    }
}
