using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Data
{
    public class Game : DbContext
    {
        public Game (DbContextOptions<Game> options)
            : base(options)
        {
        }

        public DbSet<Healthplayer> Healthplayers { get; set; }
        public DbSet<Preset> Presets { get; set; }
        public DbSet<Speedplayer> Speedplayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Healthplayer>().ToTable("Healthplayer");
            modelBuilder.Entity<Preset>().ToTable("Preset");
            modelBuilder.Entity<Speedplayer>().ToTable("Speedplayer");
        }
    }
}
