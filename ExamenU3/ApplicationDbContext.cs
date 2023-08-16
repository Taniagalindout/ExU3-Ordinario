using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExamenU3.Models;

namespace ExamenU3
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options){

        }
         public DbSet<Categories>? Categories {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories()
                {
                    Id = 1,
                    Nombre = "Electrodómesticos",
                    FechaCreacion = new DateTime(),
                    FechaActualizacion = new DateTime()
                }
            );
        }
    }
}