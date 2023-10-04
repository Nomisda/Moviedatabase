namespace MovieDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class MovieSchauspieler{

    public int MovieId {get; set;}

    public int SchauspielerId {get; set;}

    public Schauspieler Schauspieler {get; set;} = null!;

    public Movie Movie {get; set;} = null!;

}