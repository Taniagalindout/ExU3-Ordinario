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
         public DbSet<Customer>? Customer {get; set;}
         public DbSet<Product>? Products {get; set;}


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
               modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    Nombre = "Samuel",
                    Apellidos = "Samuel",
                    RFC = "KAKSJKHSA",
                    CorreoElectronico = "HOLA@UTEZ",
                    Telefono = "1234567890"

                }
            );

             modelBuilder.Entity<Product>().HasData(
                new Product(){
                    Id = 1,
                    Nombre = "TestName" ,
                    Descripcion = "TestDescription",
                    Precio = 100,
                    Cantidad = 5
                }
            );
        }
    }
}