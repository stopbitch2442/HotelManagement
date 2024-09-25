using Microsoft.AspNetCore.Mvc;
using HotelManagement.Domain; // Убедитесь, что Guest определён в этом пространстве имен
using HotelManagement.Persistence; 
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
         private readonly HotelManagementDbContext _context;

         public GuestController(HotelManagementDbContext context)
         {
             _context = context;
         }

         // GET: api/guest
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
         {
             return await _context.Guests.ToListAsync();
         }

         // GET: api/guest/{id}
         [HttpGet("{id}")]
         public async Task<ActionResult<Guest>> GetGuest(int id)
         {
             var guest = await _context.Guests.FindAsync(id);

             if (guest == null)
             {
                 return NotFound();
             }

             return guest;
         }

       // POST: api/guest
       [HttpPost]
       public async Task<ActionResult<Guest>> PostGuest(Guest guest)
       {
           _context.Guests.Add(guest);
           await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
       }

       // PUT: api/guest/{id}
       [HttpPut("{id}")]
       public async Task<IActionResult> PutGuest(int id, Guest guest)
       {
           if (id != guest.Id)
           {
               return BadRequest();
           }

           _context.Entry(guest).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!GuestExists(id))
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

       // DELETE: api/guest/{id}
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteGuest(int id)
       {
           var guest = await _context.Guests.FindAsync(id);
           if (guest == null)
           {
               return NotFound();
           }

           _context.Guests.Remove(guest);
           await _context.SaveChangesAsync();

           return NoContent();
       }

       private bool GuestExists(int id)
       {
           return _context.Guests.Any(e => e.Id == id);
       }
   }
}