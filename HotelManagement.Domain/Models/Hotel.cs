using HotelManagement.Domain;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int TotalRooms { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}