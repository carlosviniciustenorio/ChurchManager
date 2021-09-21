using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.Mapping;
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MembroMap).Assembly);
        }
    }
}
