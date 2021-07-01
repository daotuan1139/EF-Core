using System;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }
        private const string connectionString = "data source=DESKTOP-DT75BB7;Database=Student;Integrated Security=SSPI;persist security info=True; ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Students> Students { get; set; }
        //public DbSet<Class> Class { get; set; }
    }
}