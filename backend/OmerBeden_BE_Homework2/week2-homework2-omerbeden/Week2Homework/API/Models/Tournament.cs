using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChessAPI.CustomValidation;

namespace ChessAPI.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        
        [PlayersValidation(ErrorMessage = "Players count of the tournament must be even number")]
        public List<Player> Players { get; set; }
    }
}
