using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Models;

namespace TMS.Data
{
   
        public class DbContextDemo : DbContext
        {
            public DbContextDemo(DbContextOptions options) : base(options) { }
            public DbSet<AllTasks> Tasks { get; set; }


        }
    
}
