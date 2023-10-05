using MovieDatabase.Models;
using MovieDatabase.Data;
using MovieDatabase.DTO;
using Microsoft.VisualBasic;

namespace MovieDatabase.Services;

public class SchauspielerService : ISchauspieler{
    private readonly MovieContext _context;

    public SchauspielerService (MovieContext c){
        _context = c;
    }

    public List<Schauspieler> GetSchauspieler(){
        return _context.Schauspieler.ToList();
    }

    public Schauspieler GetSchauspielerId(int id){
        return _context.Schauspieler.Where( s => s.Id == id).FirstOrDefault();
    }

    public bool CreateSchauspieler( Schauspieler schauspieler){
        _context.Add(schauspieler);
        return _context.SaveChanges() > 0 ;
    }

    public bool SchauspielerExists( int id){
        return _context.Schauspieler.Any( s => s.Id == id);
    }

        public void DeleteSchauspieler(int id){
        var x = _context.Schauspieler.Find(id);
        _context.Remove(x);
        _context.SaveChanges();
    }

    public void ChangeSchauspieler(Schauspieler s){
        var x = _context.Schauspieler.Find(s.Id);
        x.Name = s.Name;

        _context.SaveChanges();
    }

    public List<Movie> GetMoviesBySchauspielerId(int id){
        return _context.MovieSchauspieler.Where( ms => ms.SchauspielerId == id).Select( ms => ms.Movie).ToList();
    }
}