using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.DTOs;
using ChessAPI.Mapping;
using ChessAPI.Models;

namespace ChessAPI.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public class PlayersValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Tournament tournament = (Tournament)validationContext.ObjectInstance;
            List<PlayerDTO> players = tournament.Players.ToPlayersDTOs();
            
            if (players.Count % 2 == 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
