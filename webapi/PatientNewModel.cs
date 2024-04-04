using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi
{
    public class PatientNewModel
    {
        public long Id { get; set; }
        public string PatientName { get; set; }
        public Genders Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public Nullable<long> create_by { get; set; }
        public Nullable<long> updated_by { get; set; }
    }
    public class Genders
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }

}