using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace field_tracker_api.Models.User
{
    public class User_PassObject
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String password { get; set; }
        public String role { get; set; }
    }
}
