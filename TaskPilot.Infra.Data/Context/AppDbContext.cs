using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TaskPilot.Domain.Entities;

namespace TaskPilot.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<AppTaskEntity> Tasks => Set<AppTaskEntity>();    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppTaskEntity>(entity =>
        {
            entity.ToTable("AppTasks");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title).IsRequired();
            entity.Property(t => t.Description);
            entity.Property(t => t.Deadline);
            entity.Property(t => t.Priority);
            entity.Property(t => t.Status);
        });
    }
}
