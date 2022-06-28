using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        options.UseSqlServer(Configuration.GetConnectionString("WebApiReadDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Lead> Leads { get; set; }
}