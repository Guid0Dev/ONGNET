using Microsoft.EntityFrameworkCore;
using ONGNET.infra.entities;

namespace ongnet.infra.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}