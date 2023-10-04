using Microsoft.AspNetCore.Authorization.Infrastructure;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            var movieSchauspier = new MovieSchauspieler(){
                Movie = new Movie(){
                    Name ="Barbie Movie",
                    ReleaseDate = "2023",
                    
                    Regie = new Regisseur(){
                        Name = "Greta Gerwick",
                    }
                    
                },
                Schauspieler = new Schauspieler(){
                    Name = "Margot Robbie",

                }
            };

        context.MovieSchauspieler.Add(movieSchauspier);
        context.SaveChanges();
        }
    }
}