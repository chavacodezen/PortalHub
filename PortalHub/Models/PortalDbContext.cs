using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PortalHub.Areas.Management.Models;

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
    public virtual DbSet<Lucerna_KPI> Lucerna_KPIs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .HasColumnName("EMPLOYEE_NO");
            entity.Property(e => e.IdCompany).HasColumnName("ID_COMPANY");
            entity.Property(e => e.IdDepartment).HasColumnName("ID_DEPARTMENT");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.PasswordHash).HasColumnName("PASSWORD_HASH");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(128)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");
            entity.Property(e => e.IdPicture).HasColumnName("ID_PICTURE");
            entity.Property(e => e.IdPosition).HasColumnName("ID_POSITION");
            entity.Property(e => e.SecurityStamp).HasColumnName("SECURITY_STAMP");
            entity.Property(e => e.UserName)
                .HasMaxLength(128)
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<Lucerna_KPI>(entity =>
        {
            entity.ToTable("INDICATORS_LOG");

            entity.Property(e => e.ID_LOG).HasColumnName("ID_LOG");
            entity.Property(e => e.ID_INDICATOR).HasColumnName("ID_INDICATOR");
            entity.Property(e => e.DATE).HasColumnName("DATE");
            entity.Property(e => e.QUANTITY).HasColumnName("QUANTITY");
            entity.Property(e => e.EMPLOYEE_NO).HasColumnName("EMPLOYEE_NO");
            entity.Property(e => e.INDICATOR_DATE).HasColumnName("INDICATOR_DATE");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
