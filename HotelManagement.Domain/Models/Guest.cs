using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain;

public class Guest
{
    [Key] public int Id { get; set; } // Уникальный идентификатор гостя
    [Required] [MaxLength(100)] public string FirstName { get; set; } // Имя гостя
    [Required] [MaxLength(100)] public string LastName { get; set; } // Фамилия гостя
    [Required] [MaxLength(100)] public string Email { get; set; } // Электронная почта гостя
    [Phone] public string PhoneNumber { get; set; } // Номер телефона гостя

    public virtual ICollection<Booking> Bookings { get; set; } // Связь с бронированиями (если у вас есть такая модель)
}