using Microsoft.AspNetCore.Mvc;
using MovieDatabase.DTO;
using MovieDatabase.Helper;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Services;
using SQLitePCL;


[Route("[controller]")]

[ApiController]
public class RegieController : ControllerBase{

    private IRegie _regieService;
        public RegieController(IRegie r)
    {
        _regieService = r;
    }

    [HttpGet]
    public IActionResult GetRegisseure(){
        List<RegisseurDTO> returnRegisseure  = new List<RegisseurDTO>();
        List<Regisseur> queryResultRegisseure = _regieService.GetRegisseure();

        queryResultRegisseure.ForEach( r => {
            returnRegisseure.Add( IMapper.RegisseurtoDTO(r));
        });

        return Ok(returnRegisseure);
    }

    [HttpGet("{id}")]
    public ActionResult GetRegisseurID(int id){
        if(!_regieService.RegisseurExists(id)){
            return NotFound();
        }else{
            RegisseurDTO returnRegisseur = IMapper.RegisseurtoDTO(_regieService.GetRegisseurId(id));
            return Ok(returnRegisseur);
        }
    }

    [HttpPost]
    public ActionResult CreateRegisseur( RegisseurDTO regisseur){
        if( _regieService.RegisseurExists(regisseur.Id)){
            return BadRequest("Regisseur Already exists");
        }else{
            if( _regieService.CreateRegisseur( IMapper.RegisseurDTOtoRegissuer(regisseur))){
                return Ok("Successfully created");
            }else{
                return BadRequest();
            }
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteRegisseur( int id){
        if( _regieService.RegisseurExists(id)){
            _regieService.DeleteRegisseur(id);
            return NoContent();
        }else{
            return BadRequest("Regisseur doesn't exist");
        }
    }

    [HttpPut("{id}")]
    public ActionResult ChangeRegisseur( int id, RegisseurDTO RegisseurChange){
        if( id != RegisseurChange.Id){
            return BadRequest();
        }

        if(! _regieService.RegisseurExists(id)){
            return NotFound();
        }

        _regieService.ChangeRegisseur(IMapper.RegisseurDTOtoRegissuer(RegisseurChange));
        return NoContent();
    }


    [HttpGet("/Movie/Regie")]

    public IActionResult GetMoviesByRegisseurId([FromQuery] int RegisseurId){
        var x = _regieService.GetMoviesByRegisseurId(RegisseurId);
        List<MovieDTO> returnMovies = new List<MovieDTO>();

        x.ForEach( m =>{
            returnMovies.Add(IMapper.MovietoDTO(m));
        });

        return Ok(returnMovies);
    }

}