using System.Reflection;
using CleanArchitecture.Application.Common;
using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CleanArchitecture.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public IConfiguration Configuration { get; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
}
/*
 ///para tener 
 ///en cuenta migracion en postgres!!!!
 Scaffold-DbContext “Host=localhost;Database=CryptoMoney;Username=root;Password=L4M4sS3gvr4$” Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models
 */
