using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streeta.API.Models;

namespace Streeta.API.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().AreUnicode(false).HaveMaxLength(500);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
        public DbSet< Carrinho > Carrinho {get;set;}
        public DbSet< Categoria > Categoria {get;set;}
        public DbSet< Compra > Compra {get;set;}
        public DbSet< Cupom > Cupom {get;set;}
        public DbSet< Usuario > Usuario {get;set;}
        public DbSet< Vestuario > Vestuarios {get;set;}
    }
}