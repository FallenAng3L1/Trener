using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trener.Models;
using Trener.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Trener.DBContexts
{
    class SessionDBContext : DbContext
    {
        //definicja encji danych:
        public DbSet<SessionTable> dbSessions { get; set; }
        public string DbPath { get; }

        public SessionDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "trener.db");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
    }
}
