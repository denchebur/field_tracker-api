using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Services.Models
{
    public class User_ResultSet
    {
        public Int64 user_id { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String password { get; set; }
        public String role { get; set; }
    }
}
