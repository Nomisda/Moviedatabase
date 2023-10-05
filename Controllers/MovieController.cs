using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.DTO;
using MovieDatabase.Helper;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase.Controllers;

[Route("[controller]")]

[ApiController]
public class MovieController : Controller{

    private readonly IMovie _movieService;
    public MovieController(IMovie movieservice)
    {
        _movieService = movieservice;
    }

    [HttpGet]
    public IActionResult GetMovies(){
        List<Movie> Movies = _movieService.GetAllMovies();
        List<MovieDTO> result = new List<MovieDTO>();

        Movies.ForEach( m => {
            result.Add( IMapper.MovietoDTO(m));
        });

        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<MovieDTO> GetMovieId( int id){
        MovieDTO result = IMapper.MovietoDTO( _movieService.GetMovieId(id));
        return result;
    }

    [HttpPost]
    public IActionResult CreateMovie( [FromQuery] int RegieId, [FromQuery] int SchauspielerId, [FromBody] MovieDTO MovieCreate){

        Movie movieadd = IMapper.MovieDTOtoMovie(MovieCreate);

        if( _movieService.CreateMovie(movieadd, SchauspielerId, RegieId )){
            return Ok("Successfully created");
        }else{
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id){
        if( _movieService.MovieExists(id)){
            
            _movieService.DeleteMovie(id);
            return NoContent();
        }else{
         return NotFound();
        }
    }

    [HttpPut("{id}")]
    public ActionResult ChangeMovie( int id, MovieDTO movieChange){
        if( id != movieChange.Id){
            return BadRequest();
        }

        if( !_movieService.MovieExists(id)){
            return NotFound();
        }

        _movieService.ChangeMovie(IMapper.MovieDTOtoMovie(movieChange));
        return NoContent();
    }

    [HttpPost("/ghg")]
    public ActionResult AddSchauspielerToMovie([FromQuery] int MovieId, [FromQuery] int SchauspielerId){
        if( _movieService.AddSchauspielerToMovie(MovieId, SchauspielerId)){
            return NoContent();
        }else{
            return BadRequest();
        }
    }

    [HttpDelete("/ghg")]
    public ActionResult RemoveSchauspielerFromMovie([FromQuery] int MovieId, [FromQuery] int SchauspielerId){
        if(_movieService.RemoveSchauspielerFromMovie(MovieId, SchauspielerId)){
            return NoContent();
        }else{
            return BadRequest();
        }

    }

}