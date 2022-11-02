﻿using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id)
                .HasName("PK_UserId");
        }
    }
}