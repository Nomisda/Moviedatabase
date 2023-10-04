
using MovieDatabase.Models;
using MovieDatabase.DTO;

namespace MovieDatabase.Services;

public interface IRegie{

    List<Regisseur> GetRegisseure();

    Regisseur GetRegisseurId(int id);

    bool CreateRegisseur( Regisseur regisseur);

    bool RegisseurExists( int id);

    void DeleteRegisseur(int id);

    void ChangeRegisseur(Regisseur rChange);
    List<Movie> GetMoviesByRegisseurId(int id);
}