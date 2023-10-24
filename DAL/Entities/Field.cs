using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Field
    {
        public Int64 FieldId { get; set; }
        public Int64 UserId { get; set; }
        public String Title { get; set; }
        public String Vegetation { get; set; }
        public String Square { get; set; }
        public String Humidity { get; set; }
        public String Status { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
