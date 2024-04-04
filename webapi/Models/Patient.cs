namespace webapi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public long Id { get; set; }
        public string PatientName { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
        public Nullable<long> create_by { get; set; }
        public Nullable<long> updated_by { get; set; }
    
        public virtual Gender Gender { get; set; }
    }
}
