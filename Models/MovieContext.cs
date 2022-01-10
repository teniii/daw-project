using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProjectAPI.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; private set; }

        public MovieContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}movies.db";


        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
            .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted })
            .EnableSensitiveDataLogging()
            .UseSqlite($"Data Source={DbPath}");

    }
}