using System;
using ChessAPI.Models;

namespace ChessAPI.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String LastName { get; set; }
        public int Elo { get; set; }
        public Title Title { get; set; }
    }
}
