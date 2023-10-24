using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace field_tracker_api.Models.User
{
    public class UserUpdate_PassObject : User_PassObject
    {
        public Int64 user_id { get; set; }
    }
}
