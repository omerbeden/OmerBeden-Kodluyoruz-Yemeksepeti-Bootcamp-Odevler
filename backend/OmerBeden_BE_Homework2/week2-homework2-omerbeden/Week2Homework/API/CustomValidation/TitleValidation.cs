using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.DTOs;
using ChessAPI.Enums;
using ChessAPI.Mapping;
using ChessAPI.Models;

namespace ChessAPI.CustomValidation
{
    public class TitleValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Player player = (Player)validationContext.ObjectInstance;


            if (player.Title.Name == TitleEnum.GrandMaster.ToString() && player.Elo < 2500)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            else if (player.Title.Name == TitleEnum.InternationalMaster.ToString() && player.Elo < 2400 && player.Elo >= 2500)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            else if (player.Title.Name == TitleEnum.FideMaster.ToString() && player.Elo < 2300 && player.Elo >= 2400)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            else if (player.Title.Name == TitleEnum.CandidateMaster.ToString() && player.Elo < 2200 && player.Elo >= 2300)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            else if (player.Title.Name == TitleEnum.Noob.ToString() && player.Elo >= 2200)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }


            return ValidationResult.Success;

        }
    }
}
