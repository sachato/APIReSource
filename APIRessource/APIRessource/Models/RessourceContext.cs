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
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string mySqlConnectionStr = "server = mysql-onf.alwaysdata.net; database = onf_ressources; user = onf_test; password = adminressource; Connect Timeout = 300";
            options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<USER>(entity =>
            {
                entity.HasKey(e => e.idUser);

                entity.Property(e => e.dateCreation)
                .HasColumnType("datetime");
                //.HasDefaultValueSql("(getdate())");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.prenom)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.nom)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.pseudo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne<ROLE>(d => d.ROLE)
                .WithMany(u => u.USER)
                .HasForeignKey(d => d.idRole)
                .HasConstraintName("FK_USER_ROLE");

                entity.HasOne<ZONE_GEO>(d => d.ZONE_GEO)
                    .WithMany(p => p.USER)
                    .HasForeignKey(d => d.idZoneGeo)
                    .HasConstraintName("FK_USER_ZONE_GEO");

                entity.HasMany<RESSOURCE>(d => d.RESSOURCE)
                .WithOne(p => p.USER)
                .HasForeignKey(d => d.idRessource);

            });


            modelBuilder.Entity<RESSOURCE>(entity =>
            {
                entity.HasKey(e => e.idRessource);

                entity.HasOne(d => d.USER)
                .WithMany(p => p.RESSOURCE)
                .HasForeignKey(d => d.idUser);
            });

          /*  modelBuilder.Entity<ROLE>(entity =>
            {
                entity.HasKey(e => e.idRole);

                entity.HasMany(d => d.USER)
                .WithOne(p => p.ROLE)
                .HasForeignKey(d => d.idUser);

            });

            modelBuilder.Entity<ZONE_GEO>(entity =>
            {
                entity.HasKey(e => e.idZoneGeo);

                entity.HasMany(d => d.USER)
                .WithOne(p => p.ZONE_GEO)
                .HasForeignKey(d => d.idUser);

            });*/

        }

        public DbSet<USER> USER { get; set; }
        public DbSet<RESSOURCE> RESSOURCE { get; set; }
        public DbSet<ZONE_GEO> ZONE_GEO { get; set; }
        public DbSet<ROLE> ROLE { get; set; }

    }
}
