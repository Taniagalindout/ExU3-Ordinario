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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}