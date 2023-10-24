using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                DatabaseOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }

        public static OptionsBuild Options = new OptionsBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).UseIdentityColumn(1, 1).IsRequired().HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired(true).HasMaxLength(25).HasColumnName("name");
            modelBuilder.Entity<User>().Property(u => u.Surname).IsRequired(true).HasMaxLength(25).HasColumnName("surname");
            modelBuilder.Entity<User>().Property(u => u.Phone).IsRequired(true).HasMaxLength(25).HasColumnName("phone");
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired(true).HasMaxLength(25).HasColumnName("email");
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired(true).HasMaxLength(25).HasColumnName("password");
            modelBuilder.Entity<User>().Property(u => (String)u.Role).IsRequired(true).HasColumnName("role");
            modelBuilder.Entity<User>()
                   .HasMany<Field>(u => u.Fields)
                   .WithOne(u => u.User)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Pet
            modelBuilder.Entity<Field>().ToTable("pet");
            modelBuilder.Entity<Field>().HasKey(f => f.FieldId);
            modelBuilder.Entity<Field>().Property(f => f.FieldId).UseIdentityColumn(1, 1).IsRequired().HasColumnName("field_id");
            modelBuilder.Entity<Field>().Property(f => f.UserId).IsRequired(true).HasColumnName("user_id");
            modelBuilder.Entity<Field>().Property(f => f.Title).IsRequired(true).HasMaxLength(25).HasColumnName("title");
            modelBuilder.Entity<Field>().Property(f => f.Vegetation).IsRequired(true).HasColumnName("vegetation");
            modelBuilder.Entity<Field>().Property(f => f.Square).IsRequired(true).HasMaxLength(25).HasColumnName("square");
            modelBuilder.Entity<Field>().Property(f => f.Humidity).IsRequired(true).HasMaxLength(25).HasColumnName("humidity");
            modelBuilder.Entity<Field>().Property(f => f.Status).IsRequired(true).HasMaxLength(25).HasColumnName("status");
            modelBuilder.Entity<Field>().Property(f => f.Date).IsRequired(true).HasColumnName("date");
            modelBuilder.Entity<Field>()
                 .HasOne<User>(p => p.User)
                 .WithMany(p => p.Fields)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            #endregion

        }
    }
}
