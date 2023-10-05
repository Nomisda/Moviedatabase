using MovieDatabase.DTO;
using MovieDatabase.Models;

namespace MovieDatabase.Interfaces;

public interface IMovie{
    List<Movie> GetAllMovies();
    Movie GetMovieId(int id);

    bool CreateMovie(Movie movie, int SchauspielerId, int RegieID);

    void DeleteMovie(int id);
    bool MovieExists(int id);

    void ChangeMovie(Movie m);
    bool AddSchauspielerToMovie(int MovieId, int SchauspielerId);
    bool RemoveSchauspielerFromMovie(int Movieid, int SchauspielerId);
}