using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestSqliteCore.Models
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
        {
        }

        public employeeContext(DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Emp> Emps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {        
                optionsBuilder.UseSqlite("Data Source=database\\\\\\\\employee.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.ToTable("dept");

                entity.Property(e => e.DeptNo)
                    .HasColumnType("VARCHAR (4)")
                    .HasColumnName("deptNo");

                entity.Property(e => e.DeptName)
                    .HasColumnType("VARCHAR (20)")
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.ToTable("emp");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("VARCHAR (5)")
                    .HasColumnName("empNo");

                entity.Property(e => e.Age)
                    .HasColumnType("INT")
                    .HasColumnName("age");

                entity.Property(e => e.DeptNo)
                    .HasColumnType("VARCHAR (4)")
                    .HasColumnName("deptNo");

                entity.Property(e => e.EmpName)
                    .HasColumnType("VARCHAR (20)")
                    .HasColumnName("empName");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.DeptNo);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
