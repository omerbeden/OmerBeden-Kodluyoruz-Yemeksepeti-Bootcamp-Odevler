using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part8.Data.Models.Derivered;

namespace Part8.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomsAsync();

        Task<Room> GetRoomAsync(Guid id);
    }
}
