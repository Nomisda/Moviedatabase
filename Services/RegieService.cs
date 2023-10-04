
using System.Reflection.Metadata.Ecma335;
using MovieDatabase.Data;
using MovieDatabase.DTO;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
namespace MovieDatabase.Services;
public class RegieService : IRegie{
    private readonly MovieContext _context;

    public RegieService( MovieContext c){
        _context = c;
    }

    public List<Regisseur> GetRegisseure(){
        return _context.Regisseure.ToList();
    }

    public Regisseur GetRegisseurId(int id){
        return _context.Regisseure.Where( r => r.Id == id).FirstOrDefault();

    }

    public bool CreateRegisseur( Regisseur regisseur){
        _context.Add(regisseur);
        return _context.SaveChanges() > 0;
    }


    public void DeleteRegisseur(int id){
        var x = _context.Regisseure.Find(id);
        _context.Remove(x);
        _context.SaveChanges();
    }

    public bool RegisseurExists( int id ){
        return _context.Regisseure.Any( r => r.Id == id);
    }

    public void ChangeRegisseur(Regisseur rChange){
        var x = _context.Regisseure.Find(rChange.Id);
        x.Name = rChange.Name;

        _context.SaveChanges();
    }

    public List<Movie> GetMoviesByRegisseurId( int id){
        return _context.Movies.Where(ms => ms.Regie.Id == id).ToList();
    }
}