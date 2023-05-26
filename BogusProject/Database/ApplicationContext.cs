using BogusProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusProject.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Bogus_Ageev;Integrated Security=true;");
        }

    }
}
