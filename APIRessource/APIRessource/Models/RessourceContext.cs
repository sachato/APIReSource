using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace APIRessource.Models
{
    public partial class RessourceContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RessourceContext() : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<RESSOURCE> RESSOURCE { get; set; }
        public virtual DbSet<COMMENTAIRE> COMMENTAIRE { get; set; }
        public virtual DbSet<Consultation> Consultation { get; set; }
        public virtual DbSet<Favoris> Favoris { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string mySqlConnectionStr = "server = mysql-onf.alwaysdata.net; database = onf_ressources; user = onf_test; password = adminressource; Connect Timeout = 300";
            options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
