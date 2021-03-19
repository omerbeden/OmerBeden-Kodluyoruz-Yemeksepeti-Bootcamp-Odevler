using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessAPI.DTOs;

namespace ChessAPI.Business.Abstract
{
    public interface IFixture
    {
        void MatchPlayers(List<PlayerDTO> playersDtos);
    }
}
