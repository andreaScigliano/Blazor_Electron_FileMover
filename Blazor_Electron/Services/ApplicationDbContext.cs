using Microsoft.EntityFrameworkCore;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Electron.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Track> Track { get; set; }
        public DbSet<Track_to_Track> Track_To_Track { get; set; }
    }
}
