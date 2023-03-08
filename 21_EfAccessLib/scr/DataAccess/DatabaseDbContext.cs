using EfAccessLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EfAccessLib.DataAccess;

public class DatabaseDbContext : DbContext
{
    public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) 
        : base(options)
    {
        
    }
    public DbSet<TestModel> TestModels { get; set; }
    public DbSet<TestModelPlus> TestModelPluss { get; set; }
   
    
}