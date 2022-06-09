using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Aporte> Aporte { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { 

    }
}