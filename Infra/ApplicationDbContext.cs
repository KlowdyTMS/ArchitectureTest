using ArchitectureTest.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureTest.Infra;

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
