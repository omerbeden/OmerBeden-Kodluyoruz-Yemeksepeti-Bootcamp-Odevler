using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Part8.Data.Context;
using Part8.Data.Models.Derivered;

namespace Part8.Services
{
    public class RoomService:IRoomService
    {
        private HotelApiDbContext _dbContext;
        private IMapper _mapper;

        public RoomService(HotelApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            var roomEntity =await _dbContext.Rooms.ToListAsync();
            var result = roomEntity.Select(room => _mapper.Map<Room>(room)).ToList();
            
            return result;

        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var roomEntity = await _dbContext.Rooms.FindAsync(id);
            return _mapper.Map<Room>(roomEntity);
        }
    }
}
