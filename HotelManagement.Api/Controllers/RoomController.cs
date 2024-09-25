using Microsoft.AspNetCore.Mvc;
using HotelManagement.Domain;
using HotelManagement.Domain.DTO; // Убедитесь, что Room определён в этом пространстве имен
using HotelManagement.Persistence; // Убедитесь, что ваш DbContext доступен
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HotelManagementDbContext _context;

        public RoomController(HotelManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/room/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(RoomCreateDto roomDto)
        {
            var room = new Room
            {
                HotelId = roomDto.HotelId,
                RoomNumber = roomDto.RoomNumber,
                Type = roomDto.Type,
                Price = roomDto.Price
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
        }

        // PUT: api/room/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/room/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}