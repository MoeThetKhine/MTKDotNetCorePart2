using Microsoft.EntityFrameworkCore;
using MTKDotNetCorePart2.HttpClientApi.Model;

namespace MTKDotNetCorePart2.HttpClientApi.Database
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
