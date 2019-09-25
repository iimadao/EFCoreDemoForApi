using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public SchoolDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=39.104.19.32;port=4406;user id=root;password=123123;database=school_ddd_test;pooling=True;minpoolsize=1;maxpoolsize=10;connectiontimeout=180;");
            }
            optionsBuilder.UseLoggerFactory(LoggerFactory); 
        }

        //输出到debug输出
        public static readonly LoggerFactory LoggerFactory =
               new LoggerFactory(new[] { new DebugLoggerProvider((_, __) => true) });
        // 输出到Console
        //public static readonly LoggerFactory LoggerFactory =
        //       new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });


        public DbSet<Grade> Grades { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
