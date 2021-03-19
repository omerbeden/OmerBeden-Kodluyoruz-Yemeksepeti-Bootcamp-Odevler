using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.Business.Abstract;
using ChessAPI.CustomValidation;
using ChessAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Business.Concrete
{
    public class BasicFixture:IFixture
    {

        public  Dictionary<PlayerDTO, PlayerDTO> Fixture { get; }
        public BasicFixture()
        {
            Fixture = new Dictionary<PlayerDTO, PlayerDTO>();
        }

        public void MatchPlayers(List<PlayerDTO> playersDtos)
        {
            if (playersDtos.Count % 2==0)
            {
                for (int i = 0; i < playersDtos.Count-1; i = i + 2)
                {
                    Fixture.Add(playersDtos[i], playersDtos[i + 1]);
                }
            }
        }
    }
}
