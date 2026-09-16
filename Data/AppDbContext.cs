using Microsoft.EntityFrameworkCore;
using Buchverwaltung.Models;

namespace Buchverwaltung.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Buch> Buecher => Set<Buch>();
}
