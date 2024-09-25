using HotelManagement.Application.Interfaces;
using HotelManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Persistence;

public class HotelManagementDbContext : DbContext
{
    public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options) {}

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();
    }
}