﻿using Microsoft.EntityFrameworkCore;

namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public class WArcherDbContext : DbContext
    {
        private readonly IEntityTypeConfigurationFactory _entityTypeConfigurationFactory;

        public WArcherDbContext(
            DbContextOptions options,
            IEntityTypeConfigurationFactory entityTypeConfigurationFactory) : base(options)
        {
            _entityTypeConfigurationFactory = entityTypeConfigurationFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _entityTypeConfigurationFactory.Initialize(modelBuilder);
        }
    }
}