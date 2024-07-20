using Microsoft.EntityFrameworkCore;
using MTKDotNetCorePart2.RestClientApi.Model;

namespace MTKDotNetCorePart2.RestClientApi.Database
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }

}
