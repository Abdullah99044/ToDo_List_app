﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TodoList.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {


            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=LAPTOP-EL0218PF\\SQLEXPRESS;Database=ToDoApp;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lists>()
                .HasOne(p => p.Users)
                .WithMany(p => p.Lists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TodoLists>()
               .HasOne(p => p.Lists)
               .WithMany(p => p.TodoLists)
               .HasForeignKey(p => p.ListId)
               .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<Lists> Lists { get; set; }

        public DbSet<TodoLists> TodoLists { get; set; }





    }
}
