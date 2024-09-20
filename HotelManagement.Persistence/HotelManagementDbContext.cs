using HotelManagement.Application.Interfaces;
using HotelManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Persistence;

public class HotelManagementDbContext : DbContext, IHotelManagementDbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    
    public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options){ }


}