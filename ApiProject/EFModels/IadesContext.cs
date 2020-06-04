using System;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiProject.EFModels
{
    public partial class IadesContext : DbContext
    {
        public IadesContext(DbContextOptions<IadesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Teacher> teachers { get; set; }        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.name)
                    .HasName("Name");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.name).HasColumnName("name");

                entity.Property(e => e.surname).HasColumnName("surname");

                entity.Property(e => e.course).HasColumnName("course");

                entity.Property(e => e.telephone).HasColumnName("telephone");

                entity.Property(e => e.email).HasColumnName("email");

                entity.Property(e => e.studentID).HasColumnName("studentID");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.name);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.name).HasColumnName("name");

                entity.Property(e => e.surname).HasColumnName("surname");

                entity.Property(e => e.matter).HasColumnName("matter");

                entity.Property(e => e.telephone).HasColumnName("telephone");

                entity.Property(e => e.email).HasColumnName("email");

                entity.Property(e => e.teacherID).HasColumnName("teacherID");
            });
        }
    }
}
