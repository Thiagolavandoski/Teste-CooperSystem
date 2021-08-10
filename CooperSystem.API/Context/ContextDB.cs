using CooperSystem.API.Mapping;
using CooperSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {
        }
        public ContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMapping());
            modelBuilder.ApplyConfiguration(new MarcaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
