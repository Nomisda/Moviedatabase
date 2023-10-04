using System.Reflection.Metadata.Ecma335;

namespace MovieDatabase.Helper;
using MovieDatabase.DTO;
using MovieDatabase.Models;

public class IMapper{
    public static MovieDTO MovietoDTO( Movie m){
        MovieDTO result = new MovieDTO();
        result.Name = m.Name;
        result.Id = m.Id;
        result.ReleaseDate = m.ReleaseDate;

        return result;
        }

        public static Movie MovieDTOtoMovie( MovieDTO mDTO){
            Movie result = new Movie();
            result.Name = mDTO.Name;
            result.Id = mDTO.Id;
            result.ReleaseDate = mDTO.ReleaseDate;

            return result;
        }

        public static Schauspieler SchauspielerDTOtoSchauspieler(SchauspielerDTO sDTO){
            Schauspieler result = new Schauspieler();
            result.Name = sDTO.Name;
            result.Id = sDTO.Id;

            return result;
        }

        public static SchauspielerDTO SchauspielerToDTO( Schauspieler s ){
            SchauspielerDTO result = new SchauspielerDTO();
            result.Name = s.Name;
            result.Id = s.Id;

            return result;
        }

        public static RegisseurDTO RegisseurtoDTO(Regisseur r){
            RegisseurDTO result = new RegisseurDTO();
            result.Name = r.Name;
            result.Id = r.Id;
            return result;
        }

        public static Regisseur RegisseurDTOtoRegissuer(RegisseurDTO rDTO){
            Regisseur result = new Regisseur();
            result.Name = rDTO.Name;
            result.Id = rDTO.Id;
            return result;
        }

    }
