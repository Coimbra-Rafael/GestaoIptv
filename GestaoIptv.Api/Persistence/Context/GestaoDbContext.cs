using GestaoIptv.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoIptv.Api.Persistence.Context;

public class GestaoDbContext(DbContextOptions option) : DbContext(option)
{
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Users>().ToTable("users");
        modelBuilder.Entity<Users>().HasKey(x => x.Id);
        modelBuilder.Entity<Users>().Property(x => x.Username).HasMaxLength(150);
        modelBuilder.Entity<Users>().Property(x => x.Username).HasMaxLength(60);
        modelBuilder.Entity<Users>().Property(x => x.Password).HasMaxLength(60);
        modelBuilder.Entity<Users>().Property(x => x.State);
    }
}
