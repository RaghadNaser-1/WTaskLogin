using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTaskLogin.Models;

namespace WTaskLogin.Data
{
    public class WTaskContext : DbContext
    {
        public WTaskContext(DbContextOptions<WTaskContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Students)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Room>().ToTable(nameof(Room));
        }
    }

}
