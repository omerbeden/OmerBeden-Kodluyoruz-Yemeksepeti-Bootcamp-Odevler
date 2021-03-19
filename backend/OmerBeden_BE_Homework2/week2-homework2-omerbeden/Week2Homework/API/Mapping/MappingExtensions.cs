using System.Collections.Generic;
using ChessAPI.DTOs;
using ChessAPI.Models;

namespace ChessAPI.Mapping
{
    public static class MappingExtensions
    {

        public static List<PlayerDTO> ToPlayersDTOs(this List<Player> players)
        {
            List<PlayerDTO> playerDtos = new List<PlayerDTO>();

            foreach (var player in players)
            {
                playerDtos.Add(new PlayerDTO()
                {
                    Id = player.Id,
                    Title = player.Title,
                    Name = player.Name,
                    LastName = player.LastName,
                    Elo = player.Elo
                });
            }

            return playerDtos;
        }

        public static List<Player> ToPlayers(this List<PlayerDTO> playerDtos)
        {
            List<Player> players = new List<Player>();

            foreach (var playerDto in playerDtos)
            {
                players.Add(new Player
                {
                    Id = playerDto.Id,
                    Title = playerDto.Title,
                    Name = playerDto.Name,
                    LastName = playerDto.LastName,
                    Elo = playerDto.Elo
                });
            }
            
            return players;
        }

        public static Tournament ToTournament(this TournamentDTO tournamentDto)
        {
            Tournament tournament = new Tournament
            {
                Players = tournamentDto.Players,
                Date = tournamentDto.Date,
                Id = tournamentDto.Id,
                Location = tournamentDto.Location,
                Name = tournamentDto.Name
            };
            return tournament;
        }
    }
}
