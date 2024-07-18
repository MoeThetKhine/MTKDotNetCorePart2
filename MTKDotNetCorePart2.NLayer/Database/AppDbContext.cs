using Microsoft.EntityFrameworkCore;
using MTKDotNetCorePart2.NLayer.Model;

namespace MTKDotNetCorePart2.NLayer.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
