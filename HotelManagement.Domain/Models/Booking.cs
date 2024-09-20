using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain;

public class Booking
{
    [Key] public int Id { get; set; } // Уникальный идентификатор бронирования
    [Required] public int GuestId { get; set; } // Идентификатор гостя, который сделал бронирование
    [Required] public int RoomId { get; set; } // Идентификатор номера, который был забронирован
    [Required] public DateTime CheckInDate { get; set; } // Дата заезда
    [Required] public DateTime CheckOutDate { get; set; } // Дата выезда

    public Guest Guest { get; set; } // Связь с гостем
    public Room Room { get; set; } // Связь с номером 
}