using Microsoft.AspNetCore.Mvc;
using MovieDatabase.DTO;
using MovieDatabase.Helper;
using MovieDatabase.Interfaces;
using MovieDatabase.Models;
using MovieDatabase.Services;


[Route("[controller]")]

[ApiController]
public class SchauspielerController : ControllerBase{

    private ISchauspieler _schauspielerservice;
        public SchauspielerController(ISchauspieler s)
    {
        _schauspielerservice = s;
    }

    [HttpGet]
    public IActionResult GetSchauspieler(){
        List<SchauspielerDTO> returnSchauspieler = new List<SchauspielerDTO>();

        List<Schauspieler> queryResultSchauspieler = _schauspielerservice.GetSchauspieler();
        queryResultSchauspieler.ForEach( s => {
            returnSchauspieler.Add( IMapper.SchauspielerToDTO(s));
        });

        return Ok(returnSchauspieler);
    }

    [HttpGet("{id}")]
    public ActionResult GetSchauspielerId( int id){
        var schauspieler = _schauspielerservice.GetSchauspielerId(id);
        if(schauspieler == null){
            return NotFound("Schauspieler nicht vorhanden");
        }else{
            return Ok( IMapper.SchauspielerToDTO(schauspieler));
        }
    }

    [HttpPost]
    public ActionResult CreateSchauspieler( SchauspielerDTO schauspielerDTO){
        if( _schauspielerservice.SchauspielerExists(schauspielerDTO.Id)){
            return BadRequest("Schauspieler already exists");
        }else{


            if( _schauspielerservice.CreateSchauspieler( IMapper.SchauspielerDTOtoSchauspieler(schauspielerDTO))){
                return Ok("Successfully created");
            }else{
                
                return BadRequest();
            }
        
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSchauspieler( int id){
        if( _schauspielerservice.SchauspielerExists(id)){
            _schauspielerservice.DeleteSchauspieler(id);
            return NoContent();


        }else{
            return BadRequest("ScHauspieler doesn't exist");        }
    }

    [HttpPut("{id}")]
    public ActionResult ChangeSchauspieler( int id, SchauspielerDTO SchauspielerChange){
        if( id != SchauspielerChange.Id){
            return BadRequest();
        }

        if( !_schauspielerservice.SchauspielerExists(SchauspielerChange.Id)){
            return NotFound();
        }

        _schauspielerservice.ChangeSchauspieler(IMapper.SchauspielerDTOtoSchauspieler(SchauspielerChange));
        return NoContent();
    }

}