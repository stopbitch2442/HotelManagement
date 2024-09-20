using HotelManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Application.Interfaces;

public interface IHotelManagementDbContext
{
    DbSet<Booking> Bookings { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<Guest> Guests { get; set; }
    DbSet<Hotel> Hotels { get; set; }
    DbSet<Room> Rooms { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
}