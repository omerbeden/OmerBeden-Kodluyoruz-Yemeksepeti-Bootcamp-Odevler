using System;
using System.ComponentModel.DataAnnotations;
using ChessAPI.CustomValidation;

namespace ChessAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public int Elo { get; set; }
        [Required]
        public string Gender { get; set; }
        [TitleValidation]
        public Title Title { get; set; }

    }
}
