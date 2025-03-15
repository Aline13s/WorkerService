using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkerService.Entities.Entities;

namespace WorkerService.Data.Context
{

    public class AppDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasKey(f => f.Id);
        }
    }
}