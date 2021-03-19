using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.Models;

namespace ChessAPI.DTOs
{
    public class TournamentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public List<Player> Players { get; set; }
    }
}
