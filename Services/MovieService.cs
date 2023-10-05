using MovieDatabase.Data;
using MovieDatabase.DTO;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
namespace MovieDatabase.Services;
public class MovieService : IMovie{
    private readonly MovieContext _context;

    public MovieService( MovieContext c){
        _context = c;
    }

    public List<Movie> GetAllMovies(){
        return _context.Movies.ToList();
    }

    public Movie GetMovieId( int id){
        return _context.Movies.Where( m => m.Id == id).FirstOrDefault();
    }

    public bool CreateMovie( Movie movie, int SchauspielerId, int RegieID){
        var Regieadd = _context.Regisseure.Where( r => r.Id == RegieID).FirstOrDefault();
        movie.Regie = Regieadd;
 
        Schauspieler schauspieleradd = _context.Schauspieler.Where( s => s.Id == SchauspielerId).FirstOrDefault();
        MovieSchauspieler ms = new MovieSchauspieler(){
            Movie = movie,
            Schauspieler = schauspieleradd
        };


        _context.Add(ms);
        _context.Add(movie);
        return _context.SaveChanges() > 0 ;
    }

    public bool MovieExists( int id){
        if ( _context.Movies.Any( m => m.Id == id)){
            return true;
        }else{
            return false;
        }
    }

    public void DeleteMovie(int id){
        var m = _context.Movies.Find(id);
        _context.Remove(m);
        _context.SaveChanges();
    }

    public void ChangeMovie(Movie m){
        var x = _context.Movies.Find(m.Id);
        x.Name = m.Name;
        x.ReleaseDate = m.ReleaseDate;

        _context.SaveChanges();
    }

    public bool AddSchauspielerToMovie(int MovieId, int SchauspielerId){
        var x = _context.Movies.Where( m => m.Id == MovieId).FirstOrDefault();
        var y = _context.Schauspieler.Where( s => s.Id == SchauspielerId).FirstOrDefault();

        if( x == null || y == null){
            return false;
        }else{
            MovieSchauspieler add = new MovieSchauspieler();
            add.Schauspieler = y;
            add.Movie = x;

            _context.Add(add);
            _context.SaveChanges();
            return true;
        }
    
    }

    public bool RemoveSchauspielerFromMovie(int MovieId, int SchauspielerId){
        	var x = _context.MovieSchauspieler.Where(ms => ms.MovieId == MovieId).Where( ms=> ms.SchauspielerId == SchauspielerId).First();
            if(x == null){
                return false;
            }else{
                _context.MovieSchauspieler.Remove(x);
                _context.SaveChanges();
                return true;
            }
    }
}