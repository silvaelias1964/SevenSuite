using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;


namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        // Contructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        // Tablas, instancias
        public DbSet<SeveClie> SeveClie { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SeveClie>()
                .HasKey(c => c.id_clie);

            modelBuilder.Entity<EstadoCivil>()
                .HasKey(c => c.id_estado_civil);


        }

    }
}
