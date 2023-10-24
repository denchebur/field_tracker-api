using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace field_tracker_api.Models.Pet
{
    public class FieldUpdate_PassObject : Field_PassObject
    {
        public Int64 field_id { get; set; }
    }
}
