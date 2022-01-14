using Microsoft.EntityFrameworkCore;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieAndActors> MovieAndActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieAndActors>()
                .HasKey(x => new { x.MovieId, x.ActorId });

            modelBuilder.Entity<MovieAndActors>()
                .HasOne<Movie>(x => x.Movie)
                .WithMany(x => x.MovieAndActors)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieAndActors>()
                .HasOne<Actor>(x => x.Actor)
                .WithMany(x => x.MovieAndActors)
                .HasForeignKey(x => x.ActorId);

        }
    }
}
