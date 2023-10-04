namespace MovieDatabase.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

public class Movie{

    public int Id  { get; set;}

    public String? Name {get; set;}
    public String? ReleaseDate  {get; set;}

    public Regisseur Regie {get; set;}

    public ICollection<MovieSchauspieler> MovieSchauspieler {get; set;}
}