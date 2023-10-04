namespace MovieDatabase.Data;

using MovieDatabase.Models;
using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext{
    public MovieContext (DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public MovieContext(){

    }

    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Regisseur> Regisseure => Set<Regisseur>();
    public DbSet<Schauspieler> Schauspieler => Set<Schauspieler>();
    public DbSet<MovieSchauspieler> MovieSchauspieler => Set<MovieSchauspieler>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieSchauspieler>()
        .HasKey( ms => new { ms.MovieId, ms.SchauspielerId});

        modelBuilder.Entity<MovieSchauspieler>()
        .HasOne( m => m.Movie)
        .WithMany( ms => ms.MovieSchauspieler)
        .HasForeignKey(m => m.MovieId);

        modelBuilder.Entity<MovieSchauspieler>()
        .HasOne( m => m.Schauspieler)
        .WithMany( ms => ms.MovieSchauspieler)
        .HasForeignKey(m => m.SchauspielerId);


    }
}