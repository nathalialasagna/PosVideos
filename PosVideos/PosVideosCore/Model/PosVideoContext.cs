using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosVideosCore.Model
{
    public class PosVideoContext : DbContext
    {
        public PosVideoContext(DbContextOptions<PosVideoContext> options) : base(options)
        {

        }
        public DbSet<Video> Video { get; set; }
    }
}
