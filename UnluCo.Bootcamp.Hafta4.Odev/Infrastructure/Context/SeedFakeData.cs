

using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public static class SeedFakeData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
                        new Genre { Id=1,Name = "Drama" },
                        new Genre { Id=2,Name = "Crime" },
                        new Genre { Id=3,Name = "Action" },
                        new Genre { Id=4,Name = "Adventure" },
                        new Genre { Id=6,Name = "Romance" }
                );
            builder.Entity<Director>().HasData(
                        new Director { Id=1,FirstName = "Frank", LastName = "Darabont" },
                        new Director { Id=2,FirstName = "Francis", LastName = "Coppola" },
                        new Director { Id=3,FirstName = "Christoper", LastName = "Nolan" }
                );
            builder.Entity<Actor>().HasData(
                        new Actor { Id=1, FirstName = "Tim", LastName = "Robbins" },
                        new Actor { Id=2, FirstName = "Morgan", LastName = "Freeman" },
                        new Actor { Id=3, FirstName = "Bob", LastName = "Gunton" },

                        new Actor { Id=4,FirstName = "Marlon", LastName = "Brando" },
                        new Actor { Id=5,FirstName = "Al", LastName = "Pacino" },
                        new Actor { Id=6,FirstName = "James", LastName = "Caan" },

                        new Actor { Id=7,FirstName = "Christian", LastName = "Bale" },
                        new Actor { Id=8,FirstName = "Heath", LastName = "Ledger" },
                        new Actor { Id=9,FirstName = "Aaron", LastName = "Eckhart" }
                );
            builder.Entity<Movie>().HasData(
                        new Movie { Id=1,MovieName = "The Shawshank Redemption", ReleaseDate = new DateTime(1994, 09, 10) },
                        new Movie { Id=2,MovieName = "The Godfather", ReleaseDate = new DateTime(1972, 03, 14) },
                        new Movie { Id=3,MovieName = "The Dark Knight", ReleaseDate = new DateTime(2008, 07, 14) }
                );
            builder.Entity<IdentityRole>().HasData(
                        new IdentityRole { Id="1",Name="user"},
                        new IdentityRole { Id="2",Name="admin"}
                );
            
        }
    }
}
