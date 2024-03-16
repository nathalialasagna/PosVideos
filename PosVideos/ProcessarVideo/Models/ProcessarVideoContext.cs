using Microsoft.EntityFrameworkCore;
using PosVideosCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosVideos.Models
{
    public class ProcessarVideoContext : DbContext
    {
        public ProcessarVideoContext(DbContextOptions<ProcessarVideoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>().HasKey(b => b.Id);
        }
        public DbSet<Video> Video { get; set; }
    }
}
