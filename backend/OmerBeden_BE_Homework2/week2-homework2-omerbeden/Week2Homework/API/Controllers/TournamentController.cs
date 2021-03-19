using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.Business.Concrete;
using ChessAPI.CustomValidation;
using ChessAPI.Data;
using ChessAPI.DTOs;
using ChessAPI.Filters;
using ChessAPI.Mapping;
using ChessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private DatabaseContext _databaseContext;

        public TournamentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet()]
        public IActionResult Get()
        {

            var result = _databaseContext.Tournaments.Include(t => t.Players)
                                                                    .ThenInclude(p => p.Title).ToList();
            return Ok(result);

        }

        [HttpPost]
        [ValidationActionFilter]
        public IActionResult Post([FromBody] TournamentDTO tournamentDto)
        {

            TitleShorcutGenerator shorcutGenerator = new TitleShorcutGenerator(tournamentDto);
            shorcutGenerator.generate();
            Tournament tournament =  tournamentDto.ToTournament();
            
            _databaseContext.Tournaments.Add(tournament);
            _databaseContext.Players.AddRange(tournament.Players);
            _databaseContext.SaveChanges();
            return Ok();
        }

        [HttpGet()]
        [Route("players")]
        public IActionResult GetPlayers()
        {
            var players = _databaseContext.Players.Include(p => p.Title).ToList();
            return Ok(players);
        }

        [HttpGet()]
        [Route("Fixture")]
        public IActionResult GetFixture()
        {
            var players = _databaseContext.Players.Include(p => p.Title).ToList();
            var playersDTO = players.ToPlayersDTOs();

            BasicFixture basicFixture = new BasicFixture();

            basicFixture.MatchPlayers(playersDTO);
            
            return Ok(basicFixture.Fixture.ToList());
        }



    }
}
