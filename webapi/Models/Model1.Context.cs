namespace webapi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CRUDDATABASEEntities : DbContext
    {
        public CRUDDATABASEEntities()
            : base("name=CRUDDATABASEEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
    }
}
