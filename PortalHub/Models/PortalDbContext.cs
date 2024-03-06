using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortalHub.Models;

public partial class PortalDbContext : DbContext
{
    public PortalDbContext()
    {
    }

    public PortalDbContext(DbContextOptions<PortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Badge)
                .HasMaxLength(20)
                .HasColumnName("BADGE");
            entity.Property(e => e.CompanyKey).HasColumnName("COMPANY_KEY");
            entity.Property(e => e.DepartmentNo).HasColumnName("DEPARTMENT_NO");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("NAME");
            entity.Property(e => e.PasswordHash).HasColumnName("PASSWORD_HASH");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(128)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");
            entity.Property(e => e.PictureId).HasColumnName("PICTURE_ID");
            entity.Property(e => e.PositionKey).HasColumnName("POSITION_KEY");
            entity.Property(e => e.SecurityStamp).HasColumnName("SECURITY_STAMP");
            entity.Property(e => e.UserName)
                .HasMaxLength(128)
                .HasColumnName("USER_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
