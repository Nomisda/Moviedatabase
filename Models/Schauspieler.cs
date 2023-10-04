using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.Models;

public class Schauspieler{

    public int Id {get; set;}

    public String Name {get; set;}

     public List<MovieSchauspieler> MovieSchauspieler {get; set;}
}