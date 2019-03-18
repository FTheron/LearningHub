﻿using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();

            new DatabaseContextSeed().Seed(modelBuilder);
        }
    }
}
