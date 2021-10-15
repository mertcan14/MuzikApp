using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikMvcApp.Models
{
    public class MuzikDbContext:DbContext
    {
        public MuzikDbContext(DbContextOptions<MuzikDbContext> options):base(options)
        { 
        
        }

        public DbSet<Muzik> Muzik { get; set; }
    }
}
