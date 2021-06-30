

namespace BackendCase.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class BackendConnectionString : DbContext
    {
        public BackendConnectionString()
           : base("name=BackendConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Break>().ToTable("Breaks", schemaName: "schedule");
            modelBuilder.Entity<Shift>().ToTable("Shifts", schemaName: "schedule");
            modelBuilder.Entity<Leave>().ToTable("Leaves", schemaName: "schedule");
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Break> Breaks { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Activities> Activities { get; set; }
    }
}