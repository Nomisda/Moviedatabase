using MovieDatabase.Data;

namespace MovieDatabase.Models;

public class Regisseur {
    public int Id {get; set;}

    public String? Name {get; set;}
    public ICollection<Movie> Movies {get; set;}


}