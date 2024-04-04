using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace solution2.Models
{
    public class GenderModel
    {
        public GenderModel()
        {
            this.Patients = new HashSet<PatientModel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

       
        public virtual ICollection<PatientModel> Patients { get; set; }
    }
}