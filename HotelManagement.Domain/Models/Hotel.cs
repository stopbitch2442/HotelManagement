using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Domain;

public class Hotel
{
    [Key] public int Id { get; set; } // Уникальный идентификатор отеля

    [Required] [MaxLength(255)] public string Name { get; set; } // Название отеля

    [Required] [MaxLength(255)] public string Address { get; set; } // Адрес отеля

    [Required] public int TotalRooms { get; set; } // Общее количество номеров

    // Связь с номерами
    public ICollection<Room> Rooms { get; set; } = new List<Room>();

    // Связь с работниками
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}