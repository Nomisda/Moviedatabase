
using MovieDatabase.Models;
using MovieDatabase.DTO;

namespace MovieDatabase.Services;

public interface ISchauspieler{

    List<Schauspieler> GetSchauspieler();

    Schauspieler GetSchauspielerId(int id);

    bool CreateSchauspieler( Schauspieler schauspieler);

    bool SchauspielerExists( int id);

    void DeleteSchauspieler(int id);
    void ChangeSchauspieler(Schauspieler s);
}