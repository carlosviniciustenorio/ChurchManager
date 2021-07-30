using ChurchManager.Application.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Infrastructure.Persistencia
{
    public class CmDbContext : DbContext
    {
        public DbSet<Igreja> Igreja { get; set; }
        public DbSet<Membro> Membro { get; set; }

        public CmDbContext(DbContextOptions<CmDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Igreja>()
                .Property<int>("DirigenteId");
            modelBuilder.Entity<Igreja>()
                .HasKey("DirigenteId");

            modelBuilder.Entity<Membro>()
                .Property<int>("IgrejaId");
            modelBuilder.Entity<Membro>()
                .HasKey("IgrejaId");
        }
    }
}
