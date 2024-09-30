using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.Models
{
    public class DataContext : DbContext
    {
        public DbSet<DanceType> DanceTypes { get; set; }
        public DbSet<GroupDanceType> GroupDanceTypes { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentSchedule> StudentSchedules{ get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanceType>().HasKey(d => new { d.Id});
       
            modelBuilder.Entity<GroupDanceType>().HasKey(gd => new {gd.DanceTypeId, gd.GroupId});
            modelBuilder.Entity<GroupDanceType>()
                .HasOne(gd => gd.DanceType)
                .WithMany(d => d.GroupDanceTypes)
                .HasForeignKey(gd => gd.DanceTypeId);
            modelBuilder.Entity<GroupDanceType>()
                .HasOne(gd => gd.Group)
                .WithMany(g => g.DanceTypes)
                .HasForeignKey(gd => gd.GroupId);

            modelBuilder.Entity<GroupStudent>().HasKey(gs => new { gs.StudentId, gs.GroupId });
            modelBuilder.Entity<GroupStudent>()
                .HasOne(gs => gs.Students)
                .WithMany(s => s.GroupsStudents)
                .HasForeignKey(gs => gs.StudentId);
            modelBuilder.Entity<GroupStudent>()
                .HasOne(gs => gs.Groups)
                .WithMany(g => g.GroupStudents)
                .HasForeignKey(gs => gs.GroupId);

            modelBuilder.Entity<Schedule>().HasKey(s => new { s.Id});
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.DanceType)
                .WithMany(d => d.Schedule)
                .HasForeignKey(s => s.DanceTypeId);
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Schedules)
                .HasForeignKey(s => s.TeacherId);


            modelBuilder.Entity<Groups>().HasKey(g => new { g.Id });

            modelBuilder.Entity<Students>().HasKey(s => new {s.Id});

            modelBuilder.Entity<StudentSchedule>().HasKey(ss => new { ss.StudentId, ss.ScheduleId });
            modelBuilder.Entity<StudentSchedule>()
                .HasOne(ss => ss.Students)
                .WithMany(s => s.StudentSchedules)
                .HasForeignKey(ss => ss.StudentId);
            modelBuilder.Entity<StudentSchedule>()
                .HasOne(ss => ss.Schedules)
                .WithMany(s => s.StudentSchedules)
                .HasForeignKey(ss => ss.ScheduleId);

            modelBuilder.Entity<Teacher>().HasKey(t => new { t.Id });


        }
    }
}
