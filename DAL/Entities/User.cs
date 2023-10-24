using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public Int64 UserId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }

        public ICollection<Field> Fields { get; set; }
    }

    //public enum Roles
    //{
    //    [Description("User")]
    //    User,
    //    [Description("Vet")]
    //    Vet,
    //    [Description("Admin")]
    //    Admin
    //}
}
