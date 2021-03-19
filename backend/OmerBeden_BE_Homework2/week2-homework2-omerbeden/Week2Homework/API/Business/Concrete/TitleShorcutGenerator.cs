using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.DTOs;
using ChessAPI.Enums;
using ChessAPI.Models;

namespace ChessAPI.Business.Concrete
{
    public class TitleShorcutGenerator
    {
        private TournamentDTO _tournamentDTO;

        public TitleShorcutGenerator(TournamentDTO tournamentDto)
        {
            _tournamentDTO = tournamentDto;
        }

        public TournamentDTO generate()
        {
            foreach (var player in _tournamentDTO.Players)
            {
                if (player.Title.Name == TitleEnum.InternationalMaster.ToString())
                {
                    player.Title = new InternationalMaster{Name = player.Title.Name, Id=player.Title.Id};
                }
                
                else if (player.Title.Name == TitleEnum.CandidateMaster.ToString())
                {
                    player.Title = new CandidateMaster() { Name = player.Title.Name, Id = player.Title.Id };
                }
                
                else if (player.Title.Name == TitleEnum.FideMaster.ToString())
                {
                    player.Title = new FideMaster() { Name = player.Title.Name, Id = player.Title.Id };
                }
                
                else if (player.Title.Name == TitleEnum.GrandMaster.ToString())
                {
                    player.Title = new GrandMaster() { Name = player.Title.Name, Id = player.Title.Id };
                }

                else if (player.Title.Name == TitleEnum.Noob.ToString())
                {
                    player.Title = new Noob() { Name = player.Title.Name, Id = player.Title.Id };
                }
            }

            return _tournamentDTO;
        }
    }
}
