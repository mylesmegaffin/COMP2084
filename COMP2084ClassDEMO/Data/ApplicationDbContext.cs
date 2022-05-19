using COMP2084ClassDEMO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMP2084ClassDEMO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // reference each Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // When our models are create we will need this to generate our models in the database
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
