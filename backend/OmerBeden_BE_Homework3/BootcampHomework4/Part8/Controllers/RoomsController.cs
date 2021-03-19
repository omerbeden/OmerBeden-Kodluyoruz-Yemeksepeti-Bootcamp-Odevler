using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Part8.Services;

namespace Part8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class RoomsController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            var rooms = _roomService.GetRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(Guid id)
        {
            var room = _roomService.GetRoomAsync(id);
            return Ok(room);
        }
    }
}
