using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                
                context.Genres.AddRange(
                        new Genre { Name="Drama"},
                        new Genre { Name="Crime"},
                        new Genre { Name="Action"},
                        new Genre { Name="Adventure"},
                        new Genre { Name="Romance"}
                    );

                context.Directors.AddRange(
                        new Director { FirstName="Frank", LastName="Darabont"},
                        new Director { FirstName="Francis", LastName="Coppola"},
                        new Director { FirstName="Christoper", LastName="Nolan"}
                    );

               
                context.Movies.AddRange(
                        new Movie { MovieName = "The Shawshank Redemption", DirectorId = 1, GenreId = 1, ReleaseDate = new DateTime(1994, 09, 10) },
                        new Movie { MovieName = "The Godfather", DirectorId = 2, GenreId = 2, ReleaseDate = new DateTime(1972, 03, 14) },
                        new Movie { MovieName = "The Dark Knight", DirectorId = 3, GenreId = 3, ReleaseDate = new DateTime(2008, 07, 14) }
                    );
                context.Actors.AddRange(
                        new Actor { FirstName= "Tim", LastName="Robbins"},
                        new Actor { FirstName= "Morgan", LastName="Freeman"},
                        new Actor { FirstName= "Bob", LastName="Gunton"},

                        new Actor { FirstName= "Marlon", LastName="Brando"},
                        new Actor { FirstName= "Al", LastName="Pacino"},
                        new Actor { FirstName= "James", LastName="Caan"},

                        new Actor { FirstName= "Christian", LastName="Bale"},
                        new Actor { FirstName= "Heath", LastName="Ledger"},
                        new Actor { FirstName= "Aaron", LastName="Eckhart"}
                    );
                context.MovieAndActors.AddRange(
                        new MovieAndActor { ActorId=1,MovieId=1},
                        new MovieAndActor { ActorId=2,MovieId=1},
                        new MovieAndActor { ActorId=3,MovieId=1},
                        new MovieAndActor { ActorId=4,MovieId=2},
                        new MovieAndActor { ActorId=5,MovieId=2},
                        new MovieAndActor { ActorId=6,MovieId=2},
                        new MovieAndActor { ActorId=7,MovieId=3},
                        new MovieAndActor { ActorId=8,MovieId=3},
                        new MovieAndActor { ActorId=9,MovieId=3}
                    );

                context.SaveChanges();


            }
        }
    }
}
